using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PHPReader))]
public class PHPReaderEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		PHPReader phpReader = (PHPReader)target;

		if (GUILayout.Button("Create All JSONs"))
		{
			phpReader.ReadAll();
		}
	}
}
