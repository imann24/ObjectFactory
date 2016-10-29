/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using UnityEngine;
using System.Collections;

public class CombinationFactoryController : AdvancedFactoryController {
	public GameObject CombinableFactoryObjectPrefab;

	protected override FactoryObject createFactoryObject (FactoryObjectDescriptor descriptor) {
		if (descriptor is CombinableFactoryObjectDescriptor) {
			GameObject factoryObject = (GameObject) Instantiate(CombinableFactoryObjectPrefab, Vector3.up * SPAWN_OFFSET, Quaternion.identity);
			CombinableFactoryObject factoryObjectController = factoryObject.GetComponent<CombinableFactoryObject>();
			factoryObjectController.Descriptor = descriptor;
			return factoryObjectController;
		} else {
			return base.createFactoryObject (descriptor);
		}
	}
}
