using UnityEngine;
using System.Collections;

public class WorldObject : MonoBehaviour {
	const float CAPTURED_SPRITE_SCALE = 0.5f;
	const float OFFSET_INCREMENT = 0.035f;

	protected Vector3 offset = Vector3.zero;
	protected FactoryController factoryController;
	protected bool active = false;
	SpriteRenderer renderer;

	// Use this for initialization
	void Awake () {
		setReferences();
	}

	void Start () {
		init();
	}

	public void SetFactoryController (FactoryController controller) {
		this.factoryController = controller;
	}

	virtual protected void init () {
		setActive();
	}

	virtual protected void setReferences () {
		renderer = GetComponent<SpriteRenderer>();
	}

	void setActive () {
		active = true;
	}

	void setInactive () {
		active = false;
	}

	public virtual Color GetColor () {
		if (renderer){ 
			return renderer.color;
		} else {
			return default(Color);
		}
	}

	public virtual void SetColor (Color color) {
		if (renderer) {
			renderer.color = color;
		}
	}


	protected void captureSprite (WorldObject worldObject) {
		Transform spriteTransform = worldObject.transform;
		spriteTransform.SetParent(transform);
		spriteTransform.localScale *= CAPTURED_SPRITE_SCALE;
		spriteTransform.localPosition = offset;
		updateOffset();
	}

	protected void updateOffset () {
		offset += Vector3.right * OFFSET_INCREMENT;
		offset += Vector3.down * OFFSET_INCREMENT;
	}
}
