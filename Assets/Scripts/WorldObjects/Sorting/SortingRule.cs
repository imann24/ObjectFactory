/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using UnityEngine;
using System.Collections;

public class SortingRule : WorldObject {
	protected const int DEFAULT_INDEX = 0;
	protected Sorter.DetermineIndexAction determineSort;
	protected Sorter.DetermineIndexAction peekSort;
	protected Sorter.DetermineIndexAction tickSort;

	protected override void setReferences () {
		assignActions();
	}

	protected override void init () {
		subscribeAction();
	}

	protected virtual void assignActions () {
		determineSort = defaultSort;
		peekSort = defaultSort;
		tickSort = defaultSort;
	}

	void subscribeAction () {
		Sorter sorter;
		// Meant to be a null check (assignment is intentional)
		if (sorter = GetComponent<Sorter>()) {
			sorter.SubscribeDetermineIndex(determineSort, peekSort, tickSort);
		}
	}

	protected int defaultSort (WorldObject objectToSort, WorldSocket[] possibleOutputs) {
		return DEFAULT_INDEX;
	}
}
