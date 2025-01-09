using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Search;
using UnityEditor.UIElements;
using static Unity.VisualScripting.Member;

public class HeatmapsWindow : EditorWindow
{
    DamagerType damagerType;

    List<Vector3> positions = new List<Vector3>();

    List<GameObject> heatmapObjects = new List<GameObject>();

    GameObject toInstantiate;

    Gradient gradient = new Gradient();

    float size;

    [MenuItem("Tools/Heatmaps")]
    public static void ShowWindow()
    {
        GetWindow<HeatmapsWindow>("Heatmaps");
    }

    private void OnGUI()
    {
        GUILayout.Label("Select Damager Type", EditorStyles.boldLabel);

        gradient = EditorGUILayout.GradientField(gradient);

        size = EditorGUILayout.FloatField("Cube size", size);

        //damagerType = (DamagerType)(damagerType);

        if (GUILayout.Button("Generate Heatmap")) { GenerateHeatmap(); }
		toInstantiate = (GameObject)EditorGUILayout.ObjectField("To Instantiate", toInstantiate, typeof(GameObject), true);

		if (GUILayout.Button("Deserialize Positions"))
		{
			positions.Clear();
			HMRootPositions hmPositions = JSONHeatmapDeserializer.DeserializePositionsJSON();
			foreach (var pos in hmPositions.positions)
			{
				positions.Add(new Vector3(pos.pos_x, pos.pos_y, pos.pos_z));
			}
		}

		if (GUILayout.Button("Deserialize Deaths"))
		{
			positions.Clear();
			HMRootDeaths hmDeaths = JSONHeatmapDeserializer.DeserializeDeathsJSON();
			foreach (var death in hmDeaths.deaths)
			{
				positions.Add(new Vector3(death.pos_x, death.pos_y, death.pos_z));
			}
		}

		if (GUILayout.Button("Deserialize Hits"))
		{
			positions.Clear();
			HMRootHits hmHits = JSONHeatmapDeserializer.DeserializeHitsJSON();
			foreach (var hit in hmHits.hits)
			{
				positions.Add(new Vector3(hit.pos_x, hit.pos_y, hit.pos_z));
			}
		}


		int toDelete = -1;

        for (int i = 0; i < positions.Count; ++i)
        {
            positions[i] = EditorGUILayout.Vector3Field("P" + i, positions[i]);
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("-", GUILayout.Width(20))) { toDelete = i; }
			GUILayout.EndHorizontal();
        }

        if (toDelete >= 0)
        {
			positions.RemoveAt(toDelete);
		}

		if (GUILayout.Button("+")) { positions.Add(new Vector3(0, 0, 0)); }


	}

	struct HeatmapSphere
    {
        public Vector3 center;
        public float radius;

        public float heat;
    }

	void GenerateHeatmap()
    {
        for (int i = heatmapObjects.Count - 1; i >= 0; --i)
        {
            DestroyImmediate(heatmapObjects[i], false);
		}

        List<HeatmapSphere> heatmapSpheres = new List<HeatmapSphere>();

        // Debug.Log("\"GenerateHeatmap()\" not implemented");

        foreach (var p in positions)
        {
            GameObject GO = Instantiate(toInstantiate, p, Quaternion.identity);
			heatmapObjects.Add(GO);
		}
    }
}
