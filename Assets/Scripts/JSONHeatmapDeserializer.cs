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
public class HMRootPositions
{
	public HMPosition[] positions;
}

// ---------------------------------------------------

[Serializable]
public class HMDeath
{
	public int death_id;
	public float pos_x;
	public float pos_y;
	public float pos_z;
	public float time;
	public DamagerType reason_of_death;
}

[Serializable]
public class HMRootDeaths
{
	public HMDeath[] deaths;
}

// ----------------------------------------------------

[Serializable]
public class HMHit
{
	public int hit_id;
	public float pos_x;
	public float pos_y;
	public float pos_z;
	public float time;
	public DamagerType reason_of_hit;
}

[Serializable]
public class HMRootHits
{
	public HMHit[] hits;
}

// ---------------------------------------------------

[Serializable]
public class HMDefeat
{
	public int defeat_id;
	public float pos_x;
	public float pos_y;
	public float pos_z;
	public float time;
}

[Serializable]
public class HMRootDefeats
{
	public HMDefeat[] defeats;
}

// ---------------------------------------------------

public static class JSONHeatmapDeserializer
{
	public static HMRootPositions DeserializePositionsJSON()
	{
		string filePath = Application.dataPath + "/JSONResponse/positions.json";
		string jsonString =	"{\"positions\":" + File.ReadAllText(filePath) + "}";

		Debug.Log(jsonString);

		HMRootPositions positions = JsonUtility.FromJson<HMRootPositions>(jsonString);

		return positions;
	}

	public static HMRootDeaths DeserializeDeathsJSON()
	{
		string filePath = Application.dataPath + "/JSONResponse/deaths.json";
		string jsonString = "{\"deaths\":" + File.ReadAllText(filePath) + "}";

		Debug.Log(jsonString);

		HMRootDeaths deaths = JsonUtility.FromJson<HMRootDeaths>(jsonString);

		return deaths;
	}

	public static HMRootHits DeserializeHitsJSON()
	{
		string filePath = Application.dataPath + "/JSONResponse/hits.json";
		string jsonString = "{\"hits\":" + File.ReadAllText(filePath) + "}";

		Debug.Log(jsonString);

		HMRootHits hits = JsonUtility.FromJson<HMRootHits>(jsonString);

		return hits;
	}

	public static HMRootDefeats DeserializeDefeatsJSON()
	{
		string filePath = Application.dataPath + "/JSONResponse/defeats.json";
		string jsonString = "{\"defeats\":" + File.ReadAllText(filePath) + "}";

		Debug.Log(jsonString);

		HMRootDefeats defeats = JsonUtility.FromJson<HMRootDefeats>(jsonString);

		return defeats;
	}

}
