﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ConveyorBelt : WorldSocket {
	const float MIN_BELT_POSITION = 0.0f;
	const float MAX_BELT_POSITION = 1.0f;
	const float BASE_MOVEMENT_SPEED = 0.01f; // movement per frame
	const float SPEED_TO_FRAME_RATE_RATIO = 100;

	Animator belt;
	IEnumerator beltCoroutine;
	BeltEntranceSocket entrance;
	BeltExitSocket exit;
	bool moving = false;
	float _beltPosition = MIN_BELT_POSITION;
	float movementSpeed = BASE_MOVEMENT_SPEED;

	List<FactoryObject> objectsOnBelt = new List<FactoryObject>();
	ConveyorRail[] rails;

	public bool HideEndRails;
	public bool HideSideRails;
	public float BeltSpeed {
		get {
			return movementSpeed * SPEED_TO_FRAME_RATE_RATIO;
		}
	}
	public void SetBeltSpeed (float beltSpeed) {
		movementSpeed = beltSpeed / SPEED_TO_FRAME_RATE_RATIO;
	}

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
		ToggleRails();
	}

	protected override void setReferences () {
		base.setReferences ();
		belt = GetComponentInChildren<Animator>();
		entrance = GetComponentInChildren<BeltEntranceSocket>();
		exit = GetComponentInChildren<BeltExitSocket>();
		rails = GetComponentsInChildren<ConveyorRail>();
	}

	void ToggleRails () {
		foreach (ConveyorRail rail in rails) {
			if (rail.Position == PiecePositionType.End) {
				rail.Toggle(!HideEndRails);
			} else if (rail.Position == PiecePositionType.Side) {
				rail.Toggle(!HideSideRails);
			}
		}
	}

	#region Socket Object Methods

	public override void ReceiveInput (WorldObject worldObject) {
		entrance.ReceiveInput(worldObject);
	}

	protected override void processInput (WorldObject worldObject) {
		if (worldObject != null) {
			if (worldObject is FactoryObject) {
				FactoryObject factoryObject = (FactoryObject) worldObject;
				factoryObject.ResetBeltPosition();
				AddObjectToBelt(factoryObject);
			}
		}
	}

	protected override WorldObject getInput () {
		if (entrance.OutputAvailable(this)) {
			return entrance.SendOutput();
		} else {
			return base.getInput();
		}
	}
		
	public override WorldObject SendOutput () {
		if (exit.OutputAvailable(this)) {
			return exit.SendOutput();
		} else {
			return base.SendOutput();
		}
	}

	public override bool SupportsInput () {
		return true;
	}

	public override bool SupportsOuput () {
		return true;
	}

	public override bool OutputAvailable (WorldSocket availableFor) {
		return exit.OutputAvailable(availableFor);
	}
		
	public override bool HasObjects () {
		return objectsOnBelt.Count > 0;
	}

	#endregion

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

	public void AddObjectToBelt (FactoryObject factoryObject) {
		objectsOnBelt.Add(factoryObject);
		factoryObject.transform.SetParent(transform);
	}
		
	public void RemoveObjectFromBelt (FactoryObject factoryObject, bool sendToExit = true) {
		objectsOnBelt.Remove(factoryObject);
		if (sendToExit) {
			exit.ReceiveInput(factoryObject);
			sendOuputToReceiver();
		}
	}

	void moveBelt () {
		BeltPosition += movementSpeed;
		animateBelt();
		moveObjectsOnBelt();
	}

	void moveObjectsOnBelt () {
		foreach (FactoryObject factoryObject in objectsOnBelt) {
			factoryObject.MoveAlongBelt(movementSpeed);
			factoryObject.transform.localPosition = positionOnBelt(factoryObject.BeltPosition);
		}
		for (int i = 0; i < objectsOnBelt.Count; i++) {
			if (objectsOnBelt[i].BeltPosition == MAX_BELT_POSITION) {
				RemoveObjectFromBelt(objectsOnBelt[i]);
			}
		}
	}
		
	// Returns local position
	Vector3 positionOnBelt (float progress) {
		progress = Mathf.Clamp01(progress);
		return Vector3.Lerp(entrance.transform.localPosition, exit.transform.localPosition, progress);
	}

	void animateBelt () {
		if (belt.speed != animationSpeed) {
			belt.speed = animationSpeed;
		}
	}

	public override bool InputAvailable () {
		return entrance.OutputAvailable(this);
	}
		
	protected override void receiveInputFromSender () {
		ReceiveInput(entrance.SendOutput());	
	}

	void checkForInput () {
		if (InputAvailable()) {
			receiveInputFromSender();
		}
		if (entrance.OutputAvailable(this)) {
			processInput(getInput());
		}
	}

	IEnumerator movement () {
		while (active) {
			if (moving) {
				checkForInput();
				moveBelt();
			}
			yield return new WaitForEndOfFrame();
		}
	}
}
