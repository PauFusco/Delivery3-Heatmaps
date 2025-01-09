using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatmapController : MonoBehaviour
{
	Material mMaterial;
	MeshRenderer mMeshRenderer;

	float[] mPoints;
	int mHitCount;

	public void PrepareHeatmap()
	{
		mMeshRenderer = GetComponent<MeshRenderer>();
		mMaterial = mMeshRenderer.sharedMaterial;

		mPoints = new float[32 * 4]; // 32 point
		mHitCount = 0;
	}

	public void AddHitPoint(float xp, float yp, float zp)
	{
		if (mHitCount >= 32)
		{
			Debug.Log("Cannot add another point in the heatmap (max 32)");
			return;
		}

		mPoints[mHitCount * 4] = xp;
		mPoints[mHitCount * 4 + 1] = yp;
		mPoints[mHitCount * 4 + 2] = zp;
		mPoints[mHitCount * 4 + 3] = Random.Range(1f, 3f);

		mHitCount++;
		mHitCount %= 32;

		mMaterial.SetFloatArray("_Hits", mPoints);
		mMaterial.SetInt("_HitCount", mHitCount);
	}

	public void Reset()
	{
		mPoints = new float[32 * 4]; // 32 point
		mHitCount = 0;

		mMaterial.SetFloatArray("_Hits", mPoints);
		mMaterial.SetInt("_HitCount", mHitCount);
	}
}
