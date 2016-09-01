/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using UnityEngine;
using System.Collections;

public class BeltExitSocket : FactorySocket {
	public override void ReceiveInput (WorldObject worldObject) {
		base.ReceiveInput (worldObject);
		if (OuputReceiverAvailable()) {
			OuputReceiver.ReceiveInput(SendOuput());
		}
	}
}
