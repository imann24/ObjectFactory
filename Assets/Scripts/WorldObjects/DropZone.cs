/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using UnityEngine;
using System.Collections;

public class DropZone : WorldSocket {
	const float CAPTURED_SPRITE_SCALE = 0.5f;
	const float OFFSET_INCREMENT = 0.035f;

	System.Collections.Generic.HashSet<WorldObject> storedObjects = new System.Collections.Generic.HashSet<WorldObject>();
	UnityEngine.UI.Text inventoryCount;
	Vector3 offset = Vector3.zero;

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

	void collectObject (WorldObject worldObject) {
		storedObjects.Add(worldObject);
		captureSprite(worldObject);
		updateInventoryCount();
		if (factoryController.CheckQuotasForDropZone(this)) {
			MessageController.SendMessageToInstance(MessageUtil.QuotaMetMessage);
			FactoryController.SetConveyorBeltSpeeds(0);
		}
	}

	void captureSprite (WorldObject worldObject) {
		Transform spriteTransform = worldObject.transform;
		spriteTransform.SetParent(transform);
		spriteTransform.localScale *= CAPTURED_SPRITE_SCALE;
		spriteTransform.localPosition = offset;
		updateOffset();
	}

	void updateOffset () {
		offset += Vector3.right * OFFSET_INCREMENT;
		offset += Vector3.down * OFFSET_INCREMENT;
	}
}
