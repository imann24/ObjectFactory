/*
 * Author(s): Isaiah Mann
 * Description: Controls a factory
 */

using UnityEngine;
using System.Collections;

public class FactoryController : Controller {
	public bool ShouldStartActive;

	static FactoryController Instance;

	public delegate void FactoryAction();
	FactoryAction onRun;
	public ConveyorBeltController[] ConveyorBelts;
	Quota[] quotas;

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
		System.Collections.Generic.Dictionary<FactoryObjectDescriptorV1, int> report = dropZone.GetFactoryObjectDescriptorV1Report();
		bool areAllQuotasSatisfied = true;
		bool objectsInMotion = ObjectsInMotion();
		foreach (Quota quota in quotas) {
			bool isCurrentQuotaSatisfied = false;
			if (quota is SimpleQuota) { // Currently only supports simple quota
				foreach (FactoryObjectDescriptorV1 descriptor in report.Keys) {
					isCurrentQuotaSatisfied |= quota.CheckSatisfied(descriptor, report[descriptor]);
				}
			}
			areAllQuotasSatisfied &= isCurrentQuotaSatisfied;
			if (!isCurrentQuotaSatisfied && !objectsInMotion && quota is SimpleQuota) {
				foreach (FactoryObjectDescriptorV1 descriptor in report.Keys) {
					MessageController.SendMessageToInstance (
						MessageUtil.GetSimpleQuotaMismatchMessage(quota as SimpleQuota, new SimpleQuota(descriptor, report[descriptor])));
				}
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

	public void RunFactory () {
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
