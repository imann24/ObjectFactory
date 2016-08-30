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
		return storedObjects.Dequeue();
	}

	public override bool OutputAvailable () {
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
