/*
 * Author(s): [Insert Your Name Here], Isaiah Mann
 * Description: The fourth assignment for CS112-1: Intro to Programming with Unity dealing with arrays
 * Time to Complete: [Insert how long this assignment took you to complete]
 */

using UnityEngine;
using System.Collections;

public class Project4 : ProjectTemplate {

	protected override void setupFactory () {
		FactoryObjectDescriptorV1 blackBox = new FactoryObjectDescriptorV1(Color.black, "None", "None", false);

		FactoryObjectDescriptorV1 redBox = new FactoryObjectDescriptorV1(Color.red, "Fragile", "Priority", true);
		FactoryObjectDescriptorV1 greenBox = new FactoryObjectDescriptorV1(Color.green, "Heavy", "Economy", false);
		FactoryObjectDescriptorV1 blueBox = new FactoryObjectDescriptorV1(Color.blue, "Hazardous", "International", true);

		/*
		 * 
		 * 
		 * 
		 * 
		 */
		// START HERE

		// STEP 1: Edit the package sizes based on how many objects they contain
		int package1Size = 1;
		int package2Size = 1;
		int package3Size = 1;
		FactoryObjectDescriptor[] package1 = new FactoryObjectDescriptorV1[package1Size];
		FactoryObjectDescriptor[] package2 = new FactoryObjectDescriptorV1[package2Size];
		FactoryObjectDescriptor[] package3 = new FactoryObjectDescriptorV1[package3Size];

		// STEP 2: Assign the objects in the arrays based on the package requirements
		package1[0] = blackBox;
		// --> Add more objects to the array using the same syntax: package1[index] = boxType;

		package2[0] = blackBox;
		// --> Add more objects to the array using the same syntax: package2[index] = boxType;

		package3[0] = blackBox;
		// --> Add more objects to the array using the same syntax: package3[index] = boxType;

		// END HERE
		/*
		 * 
		 * 
		 * 
		 * 
		 */

		FactoryPackageDescriptorV1[] bundledPackages = bundlePackages(package1, package2, package3);
		foreach (FactoryPackageDescriptorV1 bundle in bundledPackages) {
			FactoryController.AddToBeltByDescriptor(bundle);
		}
	}

	FactoryPackageDescriptorV1[] bundlePackages (params FactoryObjectDescriptor[][] packages) {
		FactoryPackageDescriptorV1[] bundledPackages = new FactoryPackageDescriptorV1[packages.Length];
		int index = 0;
		foreach (FactoryObjectDescriptor[] package in packages) {
			bundledPackages[index++] = new FactoryPackageDescriptorV1(package);
		}
		return bundledPackages;
	}

}
