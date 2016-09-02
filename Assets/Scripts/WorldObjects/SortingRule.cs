/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using UnityEngine;
using System.Collections;

public class SortingRule : WorldObject {
	protected const int DEFAULT_INDEX = 0;
	protected Sorter.DetermineIndexAction determineSort;

	protected override void setReferences () {
		assignAction();
	}

	protected override void init () {
		subscribeAction();
	}

	protected virtual void assignAction () {
		determineSort = defaultSort;
	}

	void subscribeAction () {
		Sorter sorter;
		// Meant to be a null check (assignment is intentional)
		if (sorter = GetComponent<Sorter>()) {
			sorter.SubscribeDetermineIndex(determineSort);
		}
	}

	protected int defaultSort (WorldObject objectToSort, WorldSocket[] possibleOutputs) {
		return DEFAULT_INDEX;
	}
}
