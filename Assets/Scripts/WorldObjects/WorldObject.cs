using UnityEngine;
using System.Collections;

public class WorldObject : MonoBehaviour {
	protected bool active = false;

	// Use this for initialization
	void Start () {
		setReferences();
		init();
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
}
