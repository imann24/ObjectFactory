/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using UnityEngine;
using System.Collections;
using System.Linq;

public class DropZone : WorldSocket {
	System.Collections.Generic.HashSet<WorldObject> storedObjects = new System.Collections.Generic.HashSet<WorldObject>();
	UnityEngine.UI.Text inventoryCount;

	public int InventoryCount {
		get {
			return storedObjects.Count;
		}
	}

	void updateInventoryCount () {
		inventoryCount.text = storedObjects.Count.ToString();
	}

	protected override void setReferences () {
		base.setReferences ();
		inventoryCount = GetComponentInChildren<UnityEngine.UI.Text>();
	}

	public override bool SupportsInput () {
		return true;
	}

	public override void ReceiveInput (WorldObject worldObject) {
		base.ReceiveInput(worldObject);
		collectObject(worldObject);
	}
		

	public System.Collections.Generic.Dictionary<FactoryObjectDescriptorV1, int> GetFactoryObjectDescriptorV1Report () {
		System.Collections.Generic.Dictionary<FactoryObjectDescriptorV1, int> report = new System.Collections.Generic.Dictionary<FactoryObjectDescriptorV1, int>();
		foreach (WorldObject worldObject in storedObjects) {
			if (worldObject is FactoryObject) {
				FactoryObject factoryObject = (FactoryObject) worldObject;
				FactoryObjectDescriptorV1 v1Descriptor;
				if (report.ContainsKey(v1Descriptor = factoryObject.GetV1Descriptor())) {
					report[v1Descriptor]++;
				} else {
					report.Add(v1Descriptor, 1);
				}
			}
		}
		return report;
	}
		
	public FactoryPackage[] GetFactoryPackageReport () {
		System.Collections.Generic.List<FactoryPackage> packageList = new System.Collections.Generic.List<FactoryPackage>();
		foreach (WorldObject worldObject in storedObjects) {
			if (worldObject is FactoryPackage) {
				packageList.Add(worldObject as FactoryPackage);
			}
		}
		return packageList.ToArray();
	}

	public void Clear () {
		WorldObject[] storedObjectsArr = storedObjects.ToArray();
		for (int i = 0; i < storedObjectsArr.Length; i++) {
			Destroy(storedObjectsArr[i].gameObject);
		}
		storedObjects.Clear();
		updateInventoryCount();
		offset = Vector3.zero;
	}

	public Color[] GetStoredColors () {
		System.Collections.Generic.List<Color> colorList = new System.Collections.Generic.List<Color>();
		foreach (WorldObject worldObject in storedObjects) {
			Color objectColor;
			if (!colorList.Contains(objectColor = worldObject.GetColor())) {
				colorList.Add(objectColor);
			}
		}
		return colorList.ToArray();
	}

	void collectObject (WorldObject worldObject) {
		storedObjects.Add(worldObject);
		captureSprite(worldObject);
		updateInventoryCount();
		if (factoryController.CheckQuotasForDropZone(this)) {
			MessageController.SendMessageToInstance(MessageUtil.QuotaMetMessage);
			FactoryController.SetConveyorBeltSpeeds(0);
		}
	}
}
