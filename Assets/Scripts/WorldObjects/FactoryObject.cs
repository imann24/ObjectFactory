using UnityEngine;
using System.Collections;

public class FactoryObject : WorldObject {
	const string NONE_TAG_VALUE = "None";

	public const string SHIPPING_TAG = "Shipping";
	public const string MATERIALS_TAG = "Materials";
	public const string SEALED_TAG = "Sealed";
	public const string COLOR_TAG = "Color";

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

	public virtual FactoryObjectDescriptorV1 GetV1Descriptor () {
		return new FactoryObjectDescriptorV1(spriteRenderer.color, Tags[MATERIALS_TAG], Tags[SHIPPING_TAG], IsSealed);
	}

	protected override void setReferences () {
		base.setReferences();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	protected override void init () {
		base.init ();
		initStandardTags();
	}

	void initStandardTags () {
		if (!Tags.ContainsKey(SHIPPING_TAG)) {
			Tags.Add(SHIPPING_TAG, NONE_TAG_VALUE);
		}
		if (!Tags.ContainsKey(MATERIALS_TAG)) {
			Tags.Add(MATERIALS_TAG, NONE_TAG_VALUE);
		}
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
