/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using System.Linq;
using System.Collections.Generic;

public class Combiner : InputMultiplexer {
	protected List<CombinableFactoryObject> storedCombinableObjects = new List<CombinableFactoryObject>();

	public override void ReceiveInput (WorldObject worldObject) {
		if (worldObject is CombinableFactoryObject) {
			CombinableFactoryObject input = worldObject as CombinableFactoryObject;
			FactoryObject combinationResult;
			if (tryToCombine(input, out combinationResult)) {
				OuputReceiver.ReceiveInput(combinationResult);
			} else {
				storeCominableObject(input);
			}
		} else {
			base.ReceiveInput (worldObject);
		}
	}

	protected virtual bool tryToCombine (CombinableFactoryObject cominableFactoryObject, out FactoryObject result) {
		foreach (CombinableFactoryObject potentialCombination in storedCombinableObjects) {
			if (potentialCombination.CanCombineWith(cominableFactoryObject)) {
				result = cominableFactoryObject.Combine(potentialCombination);
				storedCombinableObjects.Remove(potentialCombination);
				Destroy(potentialCombination.gameObject);
				return true;
			}
		}
		result = null;
		return false;
	}

	protected virtual void storeCominableObject (CombinableFactoryObject combinableFactoryObject) {
		storedCombinableObjects.Add(combinableFactoryObject);
		base.storeObject(combinableFactoryObject);
	}
		
}
