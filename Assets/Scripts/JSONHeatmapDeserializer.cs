using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

[Serializable]
public class HMPosition
{
	public int position_id;
	public float pos_x;
	public float pos_y;
	public float pos_z;
	public float time;
}

[Serializable]
public class HeatmapPositions
{
	public HMPosition[] positions;
}

public static class JSONHeatmapDeserializer
{
	public static HeatmapPositions DeserializePositionsJSON()
	{
		string filePath = Application.dataPath + "/JSONResponse/positions.json";
		string jsonString =	"{\"positions\":" + File.ReadAllText(filePath) + "}";

		Debug.Log(jsonString);

		HeatmapPositions positions = JsonUtility.FromJson<HeatmapPositions>(jsonString);

		return positions;
	}
}
