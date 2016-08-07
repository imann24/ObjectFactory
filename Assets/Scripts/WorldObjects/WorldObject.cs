using UnityEngine;
using System.Collections;

public class WorldObject : MonoBehaviour {
	protected bool active = false;

	// Use this for initialization
	void Start () {
		init();
		setReferences();
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
