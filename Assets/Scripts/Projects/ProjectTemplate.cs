/*
 * Author(s): Isaiah Mann
 * Description: Describes the basic behaviour of a project script (editable by students in completing assigns
 */

using UnityEngine;
using System.Collections;

public class ProjectTemplate : MonoBehaviour {
	public string ProjectID {get; private set;}

	protected virtual void Awake () {
		Init();
	}

	protected virtual void Init () {
		ProjectID = gameObject.name;
	}
}
