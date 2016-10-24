/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using UnityEngine;

public class InputMultiplexer : FactorySocket {
	public WorldSocket[] Inputs;

	public override bool InputAvailable () {
		bool inputAvailable =  false;
		foreach (WorldSocket socket in Inputs) {
			inputAvailable |= socket.OutputAvailable(this);
		}
		return inputAvailable;
	}

	public override void ReceiveInput (WorldObject worldObject) {
		base.ReceiveInput (worldObject);
		if (OutputReceiverAvailable()) {
			sendOuputToReceiver();
		}
	}
		
	// Samples from first to last in the array
	protected override WorldObject getInput () {
		for (int i = 0; i < Inputs.Length; i++) {
			if (Inputs[i].OutputAvailable(this)) {
				return Inputs[i].SendOutput();
			}
		}
		return base.getInput ();
	}
}
