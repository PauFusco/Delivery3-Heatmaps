using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamagerType
{
    UNDEFINED,
    PLAYER,
    ACID,
    CHOMPER,
    SPITTER,
}

public class Damager : MonoBehaviour
{
    public DamagerType type;
}
