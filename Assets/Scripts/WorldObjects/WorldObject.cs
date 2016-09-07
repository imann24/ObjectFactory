using UnityEngine;
using System.Collections;

public class WorldObject : MonoBehaviour {
	protected FactoryController factoryController;
	protected bool active = false;

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

	}

	void setActive () {
		active = true;
	}

	void setInactive () {
		active = false;
	}

	public virtual Color GetColor () {
		SpriteRenderer renderer;
		if (renderer = GetComponent<SpriteRenderer>()){ 
			return renderer.color;
		} else {
			return default(Color);
		}
	}
}
