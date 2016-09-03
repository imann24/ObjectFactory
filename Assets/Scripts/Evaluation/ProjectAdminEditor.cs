/*
 * Author(s): Isaiah Mann
 * Description: 
 */

#if UNITY_EDITOR

using UnityEngine;
using System.Collections;
using UnityEditor;

public class ProjectAdminEditor {
	public const string HIDE_TEXT = "Hide Admin Object";
}

[CustomEditor(typeof(Project1Admin))]
public class Project1AdminEditor : Editor {

	public override void OnInspectorGUI() {
		DrawDefaultInspector();
		ProjectAdmin script = (Project1Admin)target;
		if(GUILayout.Button(ProjectAdminEditor.HIDE_TEXT)) {
			script.HideInInspector();
			EditorUtility.SetDirty(script);
		}
	}

}

[CustomEditor(typeof(Project2Admin))]
public class Project2AdminEditor : Editor {

	public override void OnInspectorGUI() {
		DrawDefaultInspector();
		ProjectAdmin script = (Project2Admin)target;
		if(GUILayout.Button(ProjectAdminEditor.HIDE_TEXT)) {
			script.HideInInspector();
			EditorUtility.SetDirty(script);
		}
	}

}

#endif