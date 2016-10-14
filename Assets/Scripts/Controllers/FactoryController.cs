/*
 * Author(s): Isaiah Mann
 * Description: Controls a factory
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FactoryController : Controller {
	protected const float SPAWN_OFFSET = 10f;
	const int INVALID_INVENTORY_COUNT = -1;

	public bool ShouldStartActive;
	public GameObject FactoryObjectPrefab;

	static FactoryController Instance;

	public delegate void FactoryAction();
	FactoryAction onRun;
	public ConveyorBeltController[] ConveyorBelts;
	Quota[] quotas;
	System.Collections.Generic.Queue<FactoryObjectDescriptor> descriptorQueue = new System.Collections.Generic.Queue<FactoryObjectDescriptor>();
	int beltIndex = 0;
	float delayBeforeEachSpawn = 0.5f;
	IEnumerator delayedAddToBeltCoroutine = null; 

	bool requirementsFailed = false;

	void Awake () {
		Instance = this;
	}

	void Start () {
		if (!ShouldStartActive) {
			SetConveyorBeltSpeeds(0);		
		}
	}

	void OnDestroy () {
		onRun = null;
	}

	public static void SubscribeRunFactoryAction (FactoryAction onRunAction) { 
		if (Instance) {
			Instance.onRun += onRunAction;
		}
	}

	public static void SetConveyorBeltSpeeds (float beltSpeed) {
		if (Instance) {
			foreach (ConveyorBeltController beltController in Instance.ConveyorBelts) {
				beltController.SetBeltSpeed(beltSpeed);
			}
		}
	}

	public static void InitInstancesWithQuotas (Quota[] quotas) {
		if (Instance) {
			Instance.InitWithQuotas(quotas);
		}
	}

	public void InitWithQuotas (Quota[] quotas) {
		this.quotas = quotas;
	}

	public bool HasQuotas () {
		return this.quotas != null;
	}

	public bool AreQuotasSatisfied (object[] arguments) {
		bool areQuotasSatisfied = true;
		foreach (Quota quota in quotas) {
			if (!quota.CheckSatisfied(arguments)) {
				areQuotasSatisfied = false;
			}
		}
		return areQuotasSatisfied;
	}

	public bool BeltsMoving () {
		bool anyBeltMoving = false;
		foreach (ConveyorBeltController beltController in ConveyorBelts) {
			anyBeltMoving |= beltController.BeltsMoving();
		}
		return anyBeltMoving;
	}
		
	public bool CheckQuotasForDropZone (DropZone dropZone) {
		if (quotas == null) {
			return false;
		}
		Dictionary<Quota, FactoryObjectDescriptorV1> closestMatchesSimpleQuota = new Dictionary<Quota, FactoryObjectDescriptorV1>();
		Dictionary<Quota, FactoryPackageDescriptorV1> closestMatchesPackageQuota = new Dictionary<Quota, FactoryPackageDescriptorV1>();
		Dictionary<FactoryObjectDescriptorV1, int> report = dropZone.GetFactoryObjectDescriptorV1Report();
		FactoryPackage[] packageList = dropZone.GetFactoryPackageReport();
		int dropZoneInventoryCount = INVALID_INVENTORY_COUNT;
		bool areAllQuotasSatisfied = true;
		bool objectsInMotion = ObjectsInMotion();
		foreach (Quota quota in quotas) {
			bool isCurrentQuotaSatisfied = false;
			if (quota is SimpleQuota) {
				foreach (FactoryObjectDescriptorV1 descriptor in report.Keys) {
					isCurrentQuotaSatisfied |= quota.CheckSatisfied(descriptor, report[descriptor]);
					if (quota is SimpleQuota) {
						if (closestMatchesSimpleQuota.ContainsKey(quota)) {
							SimpleQuota simpleQuota = quota as SimpleQuota;
							int similarities = simpleQuota.CheckSimilarities(descriptor);
							if (similarities > simpleQuota.CheckSimilarities(closestMatchesSimpleQuota[quota])) {
								closestMatchesSimpleQuota[quota] = descriptor;
							}
						}  else {
							closestMatchesSimpleQuota.Add(quota, descriptor);
						}
					}
				}
			}
			else if (quota is CountQuota) {
				if (dropZoneInventoryCount == INVALID_INVENTORY_COUNT) {
					dropZoneInventoryCount = GetDropZoneInventoryCount();
				}
				isCurrentQuotaSatisfied |= quota.CheckSatisfied(dropZoneInventoryCount);
			} else if (quota is PackageQuota) {
				foreach (FactoryPackage package in packageList) {
					isCurrentQuotaSatisfied |= quota.CheckSatisfied(package.GetReport());
					FactoryPackageDescriptorV1 packageDescriptor = package.GetV1Descriptor();
					if (closestMatchesPackageQuota.ContainsKey(quota)) {
						int similarities = quota.CheckSimilarities(packageDescriptor);
						if (similarities > quota.CheckSimilarities(closestMatchesPackageQuota[quota])) {
							closestMatchesPackageQuota[quota] = packageDescriptor;
						}
					} else {
						closestMatchesPackageQuota.Add(quota, packageDescriptor);
					}
				}
			}

			areAllQuotasSatisfied &= isCurrentQuotaSatisfied;
			if (!objectsInMotion) {
				if (!isCurrentQuotaSatisfied && quota is SimpleQuota) {
					FactoryObjectDescriptorV1 targetDescriptor = closestMatchesSimpleQuota[quota];
					MessageController.SendMessageToInstance (
						MessageUtil.GetSimpleQuotaMismatchMessage(quota as SimpleQuota, new SimpleQuota(targetDescriptor, report[targetDescriptor])));
				} else if (quota is PackageQuota) {
					MessageController.SendMessageToInstance(
						MessageUtil.GetPackageQuotaMismatchMessage(quota as PackageQuota, new PackageQuota(closestMatchesPackageQuota[quota].GetContentsAsQuotas())));
				}
			}
		}
		if (areAllQuotasSatisfied) {
			if (!CheckRequirements()) {
				// Override because the additional requirements have not been met
				areAllQuotasSatisfied = false;
				// Check whether the fail message has already been sent
				if (!requirementsFailed) {
					MessageController.SendMessageToInstance(MessageUtil.RequirementsFailedMessage);
				}
				requirementsFailed = true;
			}
		}
		return areAllQuotasSatisfied;
	}

	public bool ObjectsInMotion () {
		bool isObjectInMotion = false;
		foreach (ConveyorBeltController beltController in ConveyorBelts) {
			isObjectInMotion |= beltController.ObjectsInMotion();
		}
		return isObjectInMotion;
	}

	public bool CheckRequirements () {
		bool areRequirementsSatisified = true;
		foreach (ConveyorBeltController controller in ConveyorBelts) {
			areRequirementsSatisified &= controller.CheckRequirements();
		}
		return areRequirementsSatisified;
	}


	public int GetDropZoneInventoryCount () {
		int dropZoneInventoryCount = 0;
		foreach (ConveyorBeltController controller in ConveyorBelts) {
			dropZoneInventoryCount += controller.GetDropZoneInventoryCount();
		}
		return dropZoneInventoryCount;
	}

	public void RunFactory () {
		requirementsFailed = false;
		setFactoryController();
		ClearDropZones();
		callOnRun();
		if (!BeltsMoving()) {
			MessageController.SendMessageToInstance(MessageUtil.ZeroBeltSpeedMessage);
		}
	}

	public void ClearDropZones () {
		foreach (ConveyorBeltController controller in ConveyorBelts) {
			controller.ClearDropZones();
		}
	}
		
	public static void AddToBeltByDescriptor (int beltIndex, FactoryObjectDescriptor[] descriptors, float delayBeforeEachSpawn) {
		if (Instance) {	
			Instance.StartAddToBeltByDescriptor(beltIndex, descriptors, delayBeforeEachSpawn);
		}
	}

	public static void SetBeltIndexAndSpawnDelay (int beltIndex, float delayBeforeEachSpawn) {
		if (Instance) {
			Instance.beltIndex = beltIndex;
			Instance.delayBeforeEachSpawn = delayBeforeEachSpawn;
		}
	}

	public static void AddToBeltByDescriptor (FactoryObjectDescriptor descriptor) {
		if (Instance) {
			Instance.descriptorQueue.Enqueue(descriptor);
			if (Instance.delayedAddToBeltCoroutine == null) {
				Instance.StartCoroutine(Instance.delayedAddToBeltCoroutine = Instance.DelayedAddBeltToDescriptor());
			}
		}
	}

	IEnumerator DelayedAddBeltToDescriptor () {
		yield return new WaitForEndOfFrame();
		StartAddToBeltByDescriptor(this.beltIndex, descriptorQueue.ToArray(), this.delayBeforeEachSpawn);
		descriptorQueue.Clear();
	}

	void StartAddToBeltByDescriptor (int beltIndex, FactoryObjectDescriptor[] descriptors, float delayBeforeEachSpawn) {
		StartCoroutine(RunAddBeltByDescriptor(beltIndex, descriptors, delayBeforeEachSpawn));
	}

	IEnumerator RunAddBeltByDescriptor (int beltIndex, FactoryObjectDescriptor[] descriptors, float delayBeforeEachSpawn) {
		if (IntUtil.InRange(beltIndex, descriptors.Length)) {
			yield return new WaitForSeconds(delayBeforeEachSpawn);
			for (int i = 0; i < descriptors.Length; i++) {
				ConveyorBelts[beltIndex].AddToBelt(createFactoryObject(descriptors[i]));
				yield return new WaitForSeconds(delayBeforeEachSpawn);
			}
		}
	}

	protected virtual FactoryObject createFactoryObject (FactoryObjectDescriptor descriptor) {
		GameObject factoryObject = (GameObject) Instantiate(FactoryObjectPrefab, Vector3.up * SPAWN_OFFSET, Quaternion.identity);
		FactoryObject factoryObjectController = factoryObject.GetComponent<FactoryObject>();
		factoryObjectController.Descriptor = descriptor;
		return factoryObjectController;
	}

	void callOnRun () {
		if (onRun != null) {
			onRun();
		}
	}

	void setFactoryController () {
		foreach (ConveyorBeltController controller in ConveyorBelts) {
			controller.SetFactoryController(this);
		}
	}
}
