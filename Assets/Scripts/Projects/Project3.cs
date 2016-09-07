/*
 * Author(s): [Insert Your Name Here], Isaiah Mann
 * Description: The third assignment for CS112-1: Intro to Programming with Unity covering for loops
 * Time to Complete: [Insert how long this assignment took you to complete]
 */

using UnityEngine;
using System.Collections;

public class Project3 : ProjectTemplate {
	const float SPAWN_DELAY = 0.5f;
	const int BELT_INDEX = 0;

	protected override void setupFactory () {
		// START HERE 

		int count1 = default(int);
		Color color1 = default(Color);
		string materials1 = default(string);
		string shipping1 = default(string);
		bool isSealed1 = default(bool);

		int count2 = default(int);
		Color color2 = default(Color);
		string materials2 = default(string);
		string shipping2 = default(string);
		bool isSealed2 = default(bool);

		int count3 = default(int);
		Color color3 = default(Color);
		string materials3 = default(string);
		string shipping3 = default(string);
		bool isSealed3 = default(bool);

		float beltSpeed = default(float);

		FactoryObjectDescriptorV1[] descriptors = new FactoryObjectDescriptorV1[] {
			new FactoryObjectDescriptorV1(color1, materials1, shipping1, isSealed1),
			new FactoryObjectDescriptorV1(color2, materials2, shipping2, isSealed2),
			new FactoryObjectDescriptorV1(color3, materials3, shipping3, isSealed3)
		};

		FactoryController.SetConveyorBeltSpeeds(beltSpeed);
		// QUOTA 1:
		for (int index1 = default(int); default(bool);) {
			FactoryController.AddToBeltByDescriptor(descriptors[0]);
		}
		// QUOTA 2:
		for (int index2 = default(int); default(bool);) {
			FactoryController.AddToBeltByDescriptor(descriptors[1]);
		}
		// QUOTA 3:
		for (int index3 = default(int); default(bool);) {
			FactoryController.AddToBeltByDescriptor(descriptors[2]);
		}
			
		// END HERE
	}
}
