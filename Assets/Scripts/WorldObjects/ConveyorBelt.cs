using UnityEngine;
using System.Collections;

public class ConveyorBelt : WorldObject {
	const float MIN_BELT_POSITION = 0.0f;
	const float MAX_BELT_POSITION = 1.0f;
	const float BASE_MOVEMENT_SPEED = 0.01f; // movement per frame
	const float SPEED_TO_FRAME_RATE_RATIO = 100;

	Animator belt;
	IEnumerator beltCoroutine;
	bool moving = false;
	float _beltPosition = MIN_BELT_POSITION;
	float movementSpeed = BASE_MOVEMENT_SPEED;
	public float BeltPosition {
		get {
			return _beltPosition;
		}
		private set {
			_beltPosition = value % MAX_BELT_POSITION;
		}
	}
	float animationSpeed {
		get {
			return movementSpeed * SPEED_TO_FRAME_RATE_RATIO;
		}
	}

	protected override void init () {
		base.init ();
		StartMovement();
	}

	protected override void setReferences () {
		base.setReferences ();
		belt = GetComponentInChildren<Animator>();
	}

	public void StartMovement () {
		if (beltCoroutine == null) {
			beltCoroutine = movement();
			StartCoroutine(beltCoroutine);
		}
		moving = true;
	}

	public void StopMovement () {
		moving = false;
	}

	void moveBelt () {
		BeltPosition += movementSpeed;
		animateBelt();
	}
		
	void animateBelt () {
		if (belt.speed != animationSpeed) {
			belt.speed = animationSpeed;
		}
	}

	IEnumerator movement () {
		while (active) {
			if (moving) {
				moveBelt();
			}
			yield return new WaitForEndOfFrame();
		}
	}
}
