using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AlphaControl)), CanEditMultipleObjects]
public class AlphaControlEditor : Editor {

	public override void OnInspectorGUI()
	{
        AlphaControl myTargetMain = (AlphaControl)target;
		myTargetMain.transparency = EditorGUILayout.FloatField("Transparency", myTargetMain.transparency);

		if (myTargetMain.transparency > 1)
			myTargetMain.transparency = 1;
		if (myTargetMain.transparency < 0)
			myTargetMain.transparency = 0;
		
		foreach (var obj in targets)
        {
			AlphaControl myTarget = (AlphaControl)obj;
			myTarget.transparency = myTargetMain.transparency;         
            myTarget.ApplyTransparency();
        }
    }
}
