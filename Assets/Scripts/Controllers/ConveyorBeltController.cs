/*
 * Author(s): Isaiah Mann
 * Description: This class should be attached to the parent object of a set of conveyor belts
 */

using UnityEngine;
using System.Collections;

public class ConveyorBeltController : Controller {
	const float MAX_BELT_SPEED = 5f;
	ConveyorBelt[] belts;

	public void ClearDropZones () {
		foreach (DropZone dropZone in GetComponentsInChildren<DropZone>()) {
			dropZone.Clear();
		}
	}

	public bool ObjectsInMotion () {
		bool hasMovingObject = false;
		foreach (WorldObject worldObject in GetComponentsInChildren<WorldObject>()) {
			if (worldObject is WorldSocket && !(worldObject is DropZone)) {
				hasMovingObject |= ((WorldSocket) worldObject).HasObjects();
			}
		}
		return hasMovingObject;
	}

	public void SetFactoryController (FactoryController controller) {
		foreach (WorldObject worldObject in GetComponentsInChildren<WorldObject>()) {
			worldObject.SetFactoryController(controller);
		}
	}

	public void SetBeltSpeed(float beltSpeed) {
		beltSpeed = Mathf.Clamp(beltSpeed, 0, MAX_BELT_SPEED);
		foreach (ConveyorBelt belt in belts) {
			belt.SetBeltSpeed(beltSpeed);
		}
	}

	public void AddToBelt(FactoryObject factoryObject, int beltIndex = 0) {
		belts[beltIndex].AddObjectToBelt(factoryObject);
	}

	protected override void Init () {
		base.Init ();
		belts = GetComponentsInChildren<ConveyorBelt>();
	}

	public bool BeltsMoving () {
		float cumulativeBeltSpeed = 0;
		foreach (ConveyorBelt belt in belts) {
			cumulativeBeltSpeed += belt.BeltSpeed;
		}
		return cumulativeBeltSpeed > 0;
	}

	public bool CheckRequirements () {
		bool requirementsSatisfied = true;
		foreach (FactoryRequirement requirement in GetComponentsInChildren<FactoryRequirement>()) {
			requirementsSatisfied &= requirement.CheckSatisifed();
		}
		return requirementsSatisfied;
	}

	public int GetDropZoneInventoryCount () {
		int dropZoneInventoryCount = 0;
		foreach (DropZone dropZone in GetComponentsInChildren<DropZone>()) {
			dropZoneInventoryCount += dropZone.InventoryCount;
		}
		return dropZoneInventoryCount;
	}

	public void SetPackageMovementLock (PackageMovementLock.CheckReadyToMove isReadyToMove) {
		foreach (PackageMovementLock movementLock in GetComponentsInChildren<PackageMovementLock>()) {
			movementLock.SetIsReadyToMove(isReadyToMove);
		}
	}

	public void SetTrashLimitPerDropZone (int trashLimit) {
		foreach (TrashDropZone trash in GetComponentsInChildren<TrashDropZone>()) {
			trash.SetTrashLimit(trashLimit);
		}
	}

	public void SetColorRequirement (Color[] acceptedColors, Color[] excludedColors) {
		foreach (ColorRequirement requirement in GetComponentsInChildren<ColorRequirement>()) {
			requirement.Set(acceptedColors, excludedColors);
		}
	}
}
