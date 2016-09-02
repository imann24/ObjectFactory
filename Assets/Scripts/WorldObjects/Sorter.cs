/*
 * Author(s): Isaiah Mann
 * Description: Sorts factory objects into multiple ouputs
 */

using UnityEngine;
using System.Collections;

public class Sorter : FactorySocket {
	const int INVALID_INDEX = -1;

	public delegate int DetermineIndexAction(WorldObject objectToSort, WorldSocket[] possibleOuputs);
	DetermineIndexAction determineIndex;

	public WorldSocket[] PossibleOutputs;

	public void SubscribeDetermineIndex (DetermineIndexAction determineIndexAction) {
		determineIndex += determineIndexAction;
	}

	public WorldSocket ChooseOuput (WorldObject objectToSend) {
		int index = callDetermineIndex(objectToSend);
		if (index == INVALID_INDEX || !IntUtil.InRange(index, 0, PossibleOutputs.Length)) {
			return null;
		} else {
			return PossibleOutputs[index];
		}
	}

	int callDetermineIndex (WorldObject objectToSort) {
		if (determineIndex != null) {
			return determineIndex(objectToSort, PossibleOutputs);
		} else {
			return INVALID_INDEX;
		}
	}
}
