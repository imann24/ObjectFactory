using UnityEngine;
using System.Collections;

public class FactoryObject : WorldObject {
	float _beltPosition;
	public float BeltPosition {
		get {
			return _beltPosition;
		}
	}

	public void MoveAlongBelt (float movementSpeed) {
		_beltPosition += movementSpeed;
		_beltPosition = Mathf.Clamp01(_beltPosition);
	}

	public void ResetBeltPosition () {
		_beltPosition = 0;
	}
}
