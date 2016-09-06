/*
 * Author(s): Isaiah Mann
 * Description: Describes which colors a drop zone will satisfy
 */

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ShippingDropZone))]
public class ColorShippingRequirement : FactoryRequirement {
	public bool AcceptsAnyColor = false;
	public Color[] AcceptedColors;

	public ShippingMethod GetShipping ()  {
		return GetComponent<ShippingDropZone>().ShippingMethod;
	}

	public Color[] GetAcceptedColors () {
		return AcceptedColors;
	}
}
