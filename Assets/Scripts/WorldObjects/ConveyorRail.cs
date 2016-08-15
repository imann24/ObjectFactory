/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using UnityEngine;
using System.Collections;

public class ConveyorRail : WorldObject {
	SpriteRenderer spriteRenderer;
	public PiecePositionType Position;

	protected override void setReferences () {
		base.setReferences ();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	public void Toggle (bool isActive) {
		spriteRenderer.enabled = isActive;
	}
}
