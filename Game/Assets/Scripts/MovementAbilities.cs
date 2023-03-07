using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAbilities : MonoBehaviour
{
    [Tooltip("0-dash, 1-wall jump")]
    public bool[] movementAblilitesOwned = { false, false };

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out AbilityPickup abilityPickup))
        {
            movementAblilitesOwned[abilityPickup.abilityIndex] = true;
            Destroy(collision.gameObject);
        }
    }
}