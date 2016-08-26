/*
 * Author(s): Isaiah Mann
 * Description: Controls a group of like objects
 */

using UnityEngine;
using System.Collections;

public abstract class Controller : MonoBehaviour {
	void Awake () {
		Init();
	}

	protected virtual void Init () {

	}
}
