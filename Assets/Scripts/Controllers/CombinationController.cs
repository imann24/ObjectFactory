/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class CombinationController : SingletonController<CombinationController> {
	protected override void SetReferences () {
		dontDestroyOnLoad = true;
		base.SetReferences ();
	}

	public bool CanCombine (params CombinableFactoryObject[] combinableObjects) {
		bool canCombine = true;
		List<CombinableFactoryObject> allObjects = new List<CombinableFactoryObject>(combinableObjects);
		foreach (CombinableFactoryObject objectToCheck in allObjects) {
			// Don't check whether the object can combine with itself
			canCombine &= objectToCheck.CanCombineWith(allObjects.Except(new CombinableFactoryObject[]{objectToCheck}).ToArray());
		}
		return canCombine;
	}

	public FactoryObject GetCombination (params CombinableFactoryObject[] combinableObjects) {
		FactoryObject result = combinableObjects[0].Combine(combinableObjects[1]);
		for (int i = 2; i < combinableObjects.Length; i++) {
			if (result is CombinableFactoryObject) {
				result = combinableObjects[i].Combine(result as CombinableFactoryObject);
			} else {
				break;
			}
		}
		return result;
	}
}
