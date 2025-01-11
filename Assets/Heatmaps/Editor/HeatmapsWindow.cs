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

	HeatmapController hmController = new HeatmapController();

	Material heatmapMaterial;

	Vector2 scrollPosition = Vector2.zero;

	[MenuItem("Tools/Heatmaps")]
    public static void ShowWindow()
    {
        GetWindow<HeatmapsWindow>("Heatmaps");
    }

    private void OnGUI()
    {
		//GUILayout.Label("Select Damager Type", EditorStyles.boldLabel);

		//damagerType = (DamagerType)(damagerType);
		heatmapMaterial = (Material)EditorGUILayout.ObjectField("Heatmap Material", heatmapMaterial, typeof(Material), true);

		if (heatmapMaterial == null) { return; }

		if (GUILayout.Button("Generate Heatmap (Max 256 points)")) 
		{
			hmController.PrepareHeatmap(heatmapMaterial);
			GenerateHeatmap(); 
		}

		if (GUILayout.Button("Clear Heatmap"))
		{
			ClearHeatmap();
		}

		GUILayout.Space(10);

		scrollPosition = GUILayout.BeginScrollView(scrollPosition);

		if (GUILayout.Button("Deserialize Positions"))
		{
			positions.Clear();
			HMRootPositions hmPositions = JSONHeatmapDeserializer.DeserializePositionsJSON();
			foreach (var pos in hmPositions.positions)
			{
				positions.Add(new Vector3(pos.pos_x, pos.pos_y, pos.pos_z));
			}
		}

		if (GUILayout.Button("Deserialize Defeats"))
		{
			positions.Clear();
			HMRootDefeats hmDefeats = JSONHeatmapDeserializer.DeserializeDefeatsJSON();
			foreach (var defeat in hmDefeats.defeats)
			{
				positions.Add(new Vector3(defeat.pos_x, defeat.pos_y, defeat.pos_z));
			}
		}

		damagerType = (DamagerType)EditorGUILayout.EnumPopup("Damager Type:", damagerType);

		if (GUILayout.Button("Deserialize Deaths"))
		{
			positions.Clear();
			HMRootDeaths hmDeaths = JSONHeatmapDeserializer.DeserializeDeathsJSON();
			foreach (var death in hmDeaths.deaths)
			{
				if (damagerType == DamagerType.ANY || death.reason_of_death == damagerType)
				{
					positions.Add(new Vector3(death.pos_x, death.pos_y, death.pos_z));
				}
			}
		}

		if (GUILayout.Button("Deserialize Hits"))
		{
			positions.Clear();
			HMRootHits hmHits = JSONHeatmapDeserializer.DeserializeHitsJSON();
			foreach (var hit in hmHits.hits)
			{
				if (damagerType == DamagerType.ANY || hit.reason_of_hit == damagerType)
				{
					positions.Add(new Vector3(hit.pos_x, hit.pos_y, hit.pos_z));
				}
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

		GUILayout.EndScrollView();
	}

	void GenerateHeatmap()
    {
		foreach (var p in positions)
		{
			hmController.AddHitPoint(p.x, p.y, p.z);
		}
    }

	void ClearHeatmap()
	{
		hmController.Reset();
	}
}
