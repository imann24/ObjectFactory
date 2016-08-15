/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using UnityEngine;
using System.Collections;

public class ConveyorRail : WorldObject {
	public PiecePositionType Position;

	public void Toggle (bool isActive) {
		gameObject.SetActive(isActive);
	}
}
