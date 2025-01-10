using Gamekit3D;
using UnityEngine;

public class AttackTracker : MonoBehaviour
{
    [SerializeField]
    private PHPConnection PHPCon;

    [SerializeField]
    private PlayerController playerController;

    private void FixedUpdate()
    {
        if (playerController.canAttack && Input.GetButton("Fire1"))
        {
            //PHPCon.SendAttack(transform.position, Time.time);
        }
    }
}