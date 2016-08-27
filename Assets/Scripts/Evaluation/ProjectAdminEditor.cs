/*
 * Author(s): Isaiah Mann
 * Description: 
 */

#if UNITY_EDITOR

using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(ProjectAdmin))]
public class ProjectAdminEditor : Editor {
	public override void OnInspectorGUI() {
		ProjectAdmin script = (ProjectAdmin)target;
		script.HideInInspector();
		EditorUtility.SetDirty(script);
	}
}

#endif