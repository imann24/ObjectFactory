/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FactorySocket : WorldSocket {
	Queue<WorldObject> storedObjects = new Queue<WorldObject>();

	public override bool HasObjects () {
		return storedObjects.Count > 0;
	}

	public override void ReceiveInput (WorldObject worldObject) {
		storedObjects.Enqueue(worldObject);
		worldObject.transform.SetParent(transform);
	}

	public override WorldObject SendOuput () {
		if (storedObjects.Count > 0) {
			return storedObjects.Dequeue();
		} else {
			return null;
		}
	}

	public override WorldObject PeekOuput () {
		if (storedObjects.Count > 0) {
			return storedObjects.Peek();
		} else {
			return null;
		}
	}

	public override bool OutputAvailable (WorldSocket availableFor) {
		return storedObjects.Count > 0;
	}

	public override bool InputAvailable () {
		return true;
	}

	public override bool SupportsInput () {
		return true;
	}

	public override bool SupportsOuput () {
		return true;
	}
}
