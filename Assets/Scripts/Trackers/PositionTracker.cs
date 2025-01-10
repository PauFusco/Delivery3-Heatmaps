using UnityEngine;

public class PositionTracker : MonoBehaviour
{
    [SerializeField]
    private float baseTimeDifference = 1.0f;

    private float timeElapsed = 0.0f;

    [SerializeField]
    private PHPConnection PHPCon;

    private void LateUpdate()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > baseTimeDifference)
        {
            PHPCon.SendPosition(transform.position, Time.time);
            timeElapsed = 0.0f;
        }
    }
}