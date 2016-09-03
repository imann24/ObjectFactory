/*
 * Author(s): [Insert Your Name Here], Isaiah Mann
 * Description: The submission script for Project 2
 */

using UnityEngine;
using System.Collections;

public class Project2 : ProjectTemplate, IDelegateSortingRule {
	const int DEFAULT_INDEX = 0;

	public int DetermineSortIndex (WorldObject objectToSort, WorldSocket[] possibleOuputs) {
		if (objectToSort is FactoryObject) {
			FactoryObject factoryObject = objectToSort as FactoryObject;
			FactoryObjectDescriptorV1 descriptor = factoryObject.GetV1Descriptor();
			Color color = descriptor.Color;

			/*
			 * 
			 * 
			 * 
			 */
			// START HERE Check the value of "color" against the colors that should be sorted into each shipping method

			if (default(bool)) {
				// SORT INTO THE PLANE LANE
				return 0;
			} else if (default(bool)) {
				// SORT INTO THE BOAT LANE
				return 1;
			} else {
				// SORT INTO THE GROUND LANE
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
