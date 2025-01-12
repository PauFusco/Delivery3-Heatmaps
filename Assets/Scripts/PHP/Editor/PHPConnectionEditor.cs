using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PHPConnection))]
public class PHPConnectionEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        PHPConnection PHPCon = (PHPConnection)target;

        if (GUILayout.Button("Truncate All Tables"))
        {
            PHPCon.TruncateAll();
        }
    }
}