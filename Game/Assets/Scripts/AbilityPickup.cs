using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPickup : MonoBehaviour
{
    //This is an object which gives you said ability when you come into it's trigger
    [Tooltip("0-dash, 1-wall jump")]
    public int abilityIndex = 0;
}
