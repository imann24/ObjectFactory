/*
 * Author(s): [Insert Your Name Here], Isaiah Mann
 * Description: Script for Project 5: Crafting Functions
 * Time to Complete: [Insert how long this assignment took you to complete]
 */

using UnityEngine;

public class Project5 : ProjectTemplate, IDelegateSortingRule {
	int trashIndex = 0;
	int packageQuota = 10;
	int[] packageIndexes = new int[]{1, 2, 3};
	Color[] packageColors = new Color[]{Color.red, Color.green, Color.blue};

	bool ReadyToShip (int objectCountInPackage) {
		// TODO: Return true is objectCountInPackage is greater than or equal to packageQuota  
		Debug.Log(objectCountInPackage);
		return false;
	}

	bool ShouldKeepObject (Color objectColor) {
		// TODO: Return true if the Color is one of the Colors in the packageColors array
		return false;
	}

	int GetPackageIndex (Color objectColor) {
		// TODO: Return the index of the Color in the packageColors array, or -1 if the packageColors array does not contain this color
		return 0;
	}

	protected override void setupFactory () {
		AdvancedFactoryController.SetPackageMovementLock(ReadyToShip);
	}

	public int DetermineSortIndex (WorldObject objectToSort, WorldSocket[] possibleOuputs) {
		if (objectToSort is FactoryObject) {
			FactoryObject factoryObject = objectToSort as FactoryObject;
			FactoryObjectDescriptorV1 descriptor = factoryObject.GetV1Descriptor();
			if (ShouldKeepObject(descriptor.Color)) {
				int packageIndex = GetPackageIndex(descriptor.Color);
				if (packageIndex >= 0 && packageIndex < packageIndexes.Length) {
					return packageIndexes[packageIndex];
				} else {
					return DEFAULT_INDEX;
				}
			} else {
				return trashIndex;
			}
		} else {
			return DEFAULT_INDEX;
		}
	}

	public int PeekSortIndex (WorldObject objectToSort, WorldSocket[] possibleOutputs) {
		return DetermineSortIndex(objectToSort, possibleOutputs);
	}

	public int TickSortIndex (WorldObject objectToSort, WorldSocket[] possibleOutputs) {
		return DetermineSortIndex(objectToSort, possibleOutputs);
	}
}
