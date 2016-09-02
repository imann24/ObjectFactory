/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using UnityEngine;
using System.Collections;

public enum ShippingMethod {
	Ground,
	Boat,
	Plane,
}

public class ShippingDropZone : DropZone {
	const string SHIPPING_IMAGE_CHILD_NAME = "ShippingImage";

	public ShippingMethod ShippingMethod;
	public Sprite Ground;
	public Sprite Boat;
	public Sprite Plane;
	SpriteRenderer shippingSprite;

	protected override void setReferences () {
		base.setReferences ();
		shippingSprite = transform.FindChild(SHIPPING_IMAGE_CHILD_NAME).GetComponent<SpriteRenderer>();
	}

	protected override void init () {
		base.init ();
		setShippingImage();
	}

	void setShippingImage () {
		shippingSprite.sprite = getShippingImage();
	}

	Sprite getShippingImage () {
		switch (ShippingMethod) {
		case ShippingMethod.Ground:
			return Ground;
		case ShippingMethod.Boat:
			return Boat;
		case ShippingMethod.Plane:
			return Plane;
		default: 
			return null;
		}
	}
}
