/*
 * Author(s): [Insert Your Name Here], Isaiah Mann
 * Description: The submission script for Project 2 covering conditional statements
 * Time to Complete: [Insert how long this assignment took you to complete]
 */

using UnityEngine;
using System.Collections;

public class Project2 : ProjectTemplate, IDelegateSortingRule {
	const int DEFAULT_INDEX = 0;

	public int DetermineSortIndex (WorldObject objectToSort, WorldSocket[] possibleOuputs) {
		if (objectToSort is FactoryObject) {
			FactoryObject factoryObject = objectToSort as FactoryObject;
			FactoryObjectDescriptorV1 descriptor = factoryObject.GetV1Descriptor();


			// COLOR OF THE OBJECT:
			Color color = descriptor.Color;

			// CHECK AGAINST THESE COLORS:
			Color yellow = ColorUtil.trueYellow;
			Color red = Color.red;
			Color blue = Color.blue;
			Color green = Color.green;

			/*
			 * 
			 * 
			 * 
			 */
			// START HERE Check the value of "color" against the colors that should be sorted into each shipping method

			if (default(bool)) {
				// SORTS INTO THE PLANE:
				return 0;
			} else if (default(bool)) {
				// SORTS INTO THE BOAT:
				return 1;
			} else {
				// SORTS INTO THE GROUND:
				return 2;
			}

			// END HERE
			/*
			 * 
			 * 
			 * 
			 */
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

	protected override void init () {
		base.init ();
	}

	protected override void setupFactory () {
		// NOTHING
	}

}
