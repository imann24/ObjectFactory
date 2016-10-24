/*
 * Author(s): [Insert Your Name Here], Isaiah Mann
 * Description: Script for Project 5: Crafting Functions
 * Time to Complete: [Insert how long this assignment took you to complete]
 */

using UnityEngine;

public class Project5 : ProjectTemplate {
	int packageQuota = 10;
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

	int PackageIndex (Color objectColor) {
		// TODO: Return the index of the Color in the packageColors array, or -1 if the packageColors array does not contain this color
		return 0;
	}

	protected override void setupFactory () {
		AdvancedFactoryController.SetPackageMovementLock(ReadyToShip);
	}

}
