/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using UnityEngine;
using System.Collections;

public class ScrollViewRowBehaviour : UIBehaviour {
	public UnityEngine.UI.Text Content;

	public void SetText (string text) {
		Content.text = text;
	}
}
