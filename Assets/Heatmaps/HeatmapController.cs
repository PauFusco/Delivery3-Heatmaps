using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatmapController
{
	Material mMaterial;

	float[] mPoints;
	int mHitCount;

	public void PrepareHeatmap(Material material)
	{
		mMaterial = material;

		mPoints = new float[256 * 3]; // 256 points
		mHitCount = 0;
	}

	public void AddHitPoint(float xp, float yp, float zp)
	{
		if (mHitCount >= 256)
		{
			Debug.Log("Cannot add another point in the heatmap (max 32)");
			return;
		}

		mPoints[mHitCount * 3] = xp;
		mPoints[mHitCount * 3 + 1] = yp;
		mPoints[mHitCount * 3 + 2] = zp;

		mHitCount++;
		mHitCount %= 256;

		mMaterial.SetFloatArray("_Hits", mPoints);
		mMaterial.SetInt("_HitCount", mHitCount);
	}

	public void Reset()
	{
		mPoints = new float[256 * 3]; // 256 point
		mHitCount = 0;

		mMaterial.SetFloatArray("_Hits", mPoints);
		mMaterial.SetInt("_HitCount", mHitCount);
	}
}
