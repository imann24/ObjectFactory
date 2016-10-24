/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(FactoryPackage))]
[RequireComponent(typeof(PackageMovementLock))]
public class PackageSocket : FactorySocket {
	FactoryPackage package;
	PackageMovementLock moveLock;

	void Awake () {
		package = GetComponent<FactoryPackage>();
		moveLock = GetComponent<PackageMovementLock>();
	}

	public override void ReceiveInput (WorldObject worldObject) {
		if (worldObject is FactoryObject) {
			package.AddObject(worldObject as FactoryObject);
			checkToSendOuput();
		}
	}

	void checkToSendOuput () {
		if (OuputReceiver && OutputAvailable(OuputReceiver)) {
			OuputReceiver.ReceiveInput(SendOutput());
		}
	}

	public override bool OutputAvailable (WorldSocket availableFor) {
		return moveLock.IsReadyToMove();
	}

	public override WorldObject SendOutput () {
		return package;
	}
}
