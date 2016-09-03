/*
 * Author(s): Isaiah Mann
 * Description: Describes the basic behaviour of a project script (editable by students in completing assigns
 */

using UnityEngine;
using System.Collections;

public abstract class ProjectTemplate : MonoBehaviour {
	public string ProjectID {get; private set;}
	public GameObject FactoryObjectPrefab;

	protected virtual void Awake () {
		Init();
	}

	protected virtual void Start () {
		FactoryController.SubscribeRunFactoryAction(setupFactory);
	}

	protected virtual void Init () {
		ProjectID = gameObject.name;
	}

	protected abstract void setupFactory();
}
