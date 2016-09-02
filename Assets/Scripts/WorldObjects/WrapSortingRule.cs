/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using UnityEngine;
using System.Collections;

public class WrapSortingRule : SortingRule {
	int currentIndex = 0;

	protected virtual int wrapSortIndex (WorldObject objectToSort, WorldSocket[] possibleOuputs) {
		currentIndex %= possibleOuputs.Length;
		return currentIndex++;
	}

	protected override void assignAction () {
		determineSort = wrapSortIndex;
	}
}
