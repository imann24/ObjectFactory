using UnityEngine;
using System.Collections;

public class FactoryObject : WorldObject {
	public const string SHIPPING_TAG = "Shipping";
	public const string MATERIALS_TAG = "Materials";
	FactoryObjectDescriptor _descriptor;
	public FactoryObjectDescriptor Descriptor {
		get {
			return _descriptor;
		}
		set {
			setDescriptor(value);
			_descriptor = value;
		}
	}
	SpriteRenderer spriteRenderer;
	float _beltPosition;
	public float BeltPosition {
		get {
			return _beltPosition;
		}
	}
	public System.Collections.Generic.Dictionary<string, string> Tags = new System.Collections.Generic.Dictionary<string, string>();
	public bool IsSealed;

	public void MoveAlongBelt (float movementSpeed) {
		_beltPosition += movementSpeed;
		_beltPosition = Mathf.Clamp01(_beltPosition);
	}

	public void ResetBeltPosition () {
		_beltPosition = 0;
	}

	protected override void setReferences () {
		base.setReferences();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void setDescriptor (FactoryObjectDescriptor descriptor) {
		Tags.Clear();
		if (descriptor.Type == FactoryObjectDescriptorV1.TYPE) {
			FactoryObjectDescriptorV1 d = (FactoryObjectDescriptorV1) descriptor;
			spriteRenderer.color = d.Color;
			Tags.Add(SHIPPING_TAG, d.Shipping);
			Tags.Add(MATERIALS_TAG, d.Materials);
			IsSealed = d.IsSealed;
		}
	}
}
