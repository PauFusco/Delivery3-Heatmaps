using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingApplyPointsToHeatmap : MonoBehaviour
{
	Material mMaterial;
	MeshRenderer mMeshRenderer;

	float[] mPoints;
	int mHitCount;

	float mDelay;

	void Start()
	{
		mDelay = 3;

		mMeshRenderer = GetComponent<MeshRenderer>();
		mMaterial = mMeshRenderer.material;

		mPoints = new float[32 * 4]; //32 point 

	}

	private void OnCollisionEnter(Collision collision)
	{
		foreach (ContactPoint cp in collision.contacts)
		{
			Debug.Log("Contact with object " + cp.otherCollider.gameObject.name);

			if (cp.otherCollider.gameObject.CompareTag("HeatmapProjectile"))
			{
				addHitPoint(cp.point.x, cp.point.y, cp.point.z);

				Destroy(cp.otherCollider.gameObject);
			}
		}
	}

	public void addHitPoint(float xp, float yp, float zp)
	{
		mPoints[mHitCount * 4] = xp;
		mPoints[mHitCount * 4 + 1] = yp;
		mPoints[mHitCount * 4 + 2] = zp;
		mPoints[mHitCount * 4 + 3] = Random.Range(1f, 3f);

		mHitCount++;
		mHitCount %= 32;

		mMaterial.SetFloatArray("_Hits", mPoints);
		mMaterial.SetInt("_HitCount", mHitCount);
	}

}
