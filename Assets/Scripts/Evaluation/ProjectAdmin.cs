/*
 * Author(s): Isaiah Mann
 * Description: Hides this object in editor
 */

using UnityEngine;
using System.Collections;

public class ProjectAdmin : MonoBehaviour {
	public void HideInInspector () {
		gameObject.hideFlags = HideFlags.HideInHierarchy | HideFlags.NotEditable | HideFlags.HideInInspector;
	}
}
