/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using UnityEngine;
using System.Collections;

public class ProjectAdmin : MonoBehaviour {
	public void HideInInspector () {
	//	gameObject.hideFlags = HideFlags.HideInHierarchy | HideFlags.NotEditable | HideFlags.HideInInspector;
		gameObject.hideFlags =HideFlags.None;
	}
}
