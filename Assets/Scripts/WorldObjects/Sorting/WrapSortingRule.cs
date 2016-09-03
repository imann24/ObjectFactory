/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using UnityEngine;
using System.Collections;

public class WrapSortingRule : SortingRule {
	int currentIndex = 0;

	protected virtual int wrapSortIndex (WorldObject objectToSort, WorldSocket[] possibleOuputs) {
		currentIndex++;
		currentIndex %= possibleOuputs.Length;
		int indexToReturn = currentIndex;
		Debug.Log(currentIndex);
		return indexToReturn;
	}

	protected virtual int peekNextSortIndex (WorldObject objectToSort, WorldSocket[] possibleOutputs) {
		int nextIndex = currentIndex + 1;
		nextIndex %= possibleOutputs.Length;
		return nextIndex;
	}

	protected virtual int tickSortIndex (WorldObject objectToSort, WorldSocket[] possibleOutputs) {
		currentIndex++;
		currentIndex %= possibleOutputs.Length;
		return currentIndex;
	}

	protected override void assignActions () {
		determineSort = wrapSortIndex;
		peekSort = peekNextSortIndex;
		tickSort = tickSortIndex;
	}
}
