using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamagerType
{
    ANY = -1,
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
