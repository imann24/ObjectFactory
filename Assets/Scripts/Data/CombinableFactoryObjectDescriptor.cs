/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using UnityEngine;
using System.Collections;

public class CombinableFactoryObjectDescriptor : FactoryObjectDescriptorV1 {
	new public const string TYPE = "V1Combinable";

	public CombinableFactoryObjectDescriptor (UnityEngine.Color color, string materials, string shipping, bool isSealed, string type = TYPE)
		: base (color, materials, shipping, isSealed, type) {}
}
