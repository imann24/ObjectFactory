/*
 * Author(s): Isaiah Mann
 * Description: Used for packaging objects
 */

using UnityEngine;
using System.Collections;

public class AdvancedFactoryController : FactoryController {
	[SerializeField]
	protected GameObject FactoryPackagePrefab;

	protected override FactoryObject createFactoryObject (FactoryObjectDescriptor descriptor) {
		if (descriptor is FactoryPackageDescriptorV1) {
			FactoryPackageDescriptorV1 packageDescriptor = descriptor as FactoryPackageDescriptorV1;
			GameObject packageObject = Instantiate(FactoryPackagePrefab, Vector3.up * SPAWN_OFFSET, Quaternion.identity) as GameObject;
			FactoryPackage packageController = packageObject.GetComponent<FactoryPackage>();
			packageController.Descriptor = packageDescriptor;
			FactoryObject[] containedObjects = new FactoryObject[packageDescriptor.Contents.Length];
			int index = 0;
			foreach (FactoryObjectDescriptor objectDescriptor in packageDescriptor.Contents) {
				containedObjects[index++] = createFactoryObject(objectDescriptor);
			}
			packageController.SetContents(containedObjects);
			return packageController;
		} else {
			return base.createFactoryObject (descriptor);
		}
	}

	public static void SetPackageMovementLock (PackageMovementLock.CheckReadyToMove isReadyToMove) {
		if (Instance is AdvancedFactoryController) {
			(Instance as AdvancedFactoryController).setInstancePackageMovementLock(isReadyToMove);
		}
	}
		
	void setInstancePackageMovementLock (PackageMovementLock.CheckReadyToMove isReadyToMove) {
		foreach (ConveyorBeltController controller in ConveyorBelts) {
			controller.SetPackageMovementLock(isReadyToMove);
		}
	}

	public static void SetTrashLimitPerDropZone (int trashLimit) {
		if (Instance is AdvancedFactoryController) {
			(Instance as AdvancedFactoryController).setInstanceTrashLimitPerDropZone(trashLimit);
		}
	}

	void setInstanceTrashLimitPerDropZone (int trashLimit) {
		foreach (ConveyorBeltController belt in ConveyorBelts) {
			belt.SetTrashLimitPerDropZone(trashLimit);
		}
	}
}
