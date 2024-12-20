using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class HeatmapsWindow : EditorWindow
{
    DamagerType damagerType;

    [MenuItem("Tools/Heatmaps")]
    public static void ShowWindow()
    {
        GetWindow<HeatmapsWindow>("Heatmaps");
    }

    private void OnGUI()
    {
        GUILayout.Label("Select Damager Type", EditorStyles.boldLabel);

        //damagerType = (DamagerType)(damagerType);

        if (GUILayout.Button("Generate Heatmap")) { GenerateHeatmap(); }
    }

    void GenerateHeatmap()
    {
        Debug.Log("\"GenerateHeatmap()\" not implemented");
    }
}
