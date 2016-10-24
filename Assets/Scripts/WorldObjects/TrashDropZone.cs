/*
 * Author(s): Isaiah Mann
 * Description: A dropzone into which the user can dump unwanted objects
 */

using UnityEngine;
using System.Collections;

public class TrashDropZone : DropZone {
	int trashLimit = int.MaxValue;

	void Start () {
		updateInventoryCount();
	}

	public void SetTrashLimit (int trashLimit) {
		this.trashLimit = trashLimit;
	}

	bool exceededTrashLimit () {
		return storedObjects.Count > trashLimit;
	}

	protected override void collectObject (WorldObject worldObject) {
		storedObjects.Add(worldObject);
		captureSprite(worldObject);
		updateInventoryCount();
		if (exceededTrashLimit()) {
			MessageController.SendMessageToInstance(new Message("Quota Failed", new string[]{string.Format("Trash Limit of {0} Exceeded", trashLimit)}));
			FactoryController.SetConveyorBeltSpeeds(0);
			FactoryController.HaltSpawning();
		}
	}

	protected override void updateInventoryCount () {
		if (trashLimit == int.MaxValue) {
			base.updateInventoryCount();
		} else {
			inventoryCount.text = storedObjects.Count.ToString() + "/" + this.trashLimit.ToString();
		}

	}

}
