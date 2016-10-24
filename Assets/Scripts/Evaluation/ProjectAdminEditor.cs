/*
 * Author(s): Isaiah Mann
 * Description: Used to control project admin script (hideable in Editor)
 */

#if UNITY_EDITOR

using UnityEngine;
using System.Collections;
using UnityEditor;

public class ProjectAdminEditor : Editor {
	public const string HIDE_TEXT = "Hide Admin Object";

	protected virtual ProjectAdmin castTarget (Object target) {
		return (ProjectAdmin) target;
	}

	public override void OnInspectorGUI() {
		DrawDefaultInspector();
		ProjectAdmin script = castTarget(target);
		if(GUILayout.Button(ProjectAdminEditor.HIDE_TEXT)) {
			script.HideInInspector();
			EditorUtility.SetDirty(script);
		}
	}
}
	
[CustomEditor(typeof(Project1Admin))]
public class Project1AdminEditor : ProjectAdminEditor {
	protected override ProjectAdmin castTarget (Object target) {
		return (Project1Admin) target;
	}
}

[CustomEditor(typeof(Project2Admin))]
public class Project2AdminEditor : ProjectAdminEditor {
	protected override ProjectAdmin castTarget (Object target) {
		return (Project2Admin) target;
	}
}

[CustomEditor(typeof(Project3Admin))]
public class Project3AdminEditor : ProjectAdminEditor {
	protected override ProjectAdmin castTarget (Object target) {
		return (Project3Admin) target;
	}
}

[CustomEditor(typeof(Project4Admin))]
public class Project4AdminEditor : ProjectAdminEditor {
	protected override ProjectAdmin castTarget (Object target) {
		return (Project4Admin) target;
	}
}

[CustomEditor(typeof(Project5Admin))]
public class Project5AdminEditor : ProjectAdminEditor {
	protected override ProjectAdmin castTarget (Object target) {
		return (Project5Admin) target;
	}
}

#endif