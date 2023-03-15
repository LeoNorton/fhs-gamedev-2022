using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipInDirectionOfVelocity : MonoBehaviour
{
    [SerializeField] SpriteRenderer _rendererToFlip;
    private Rigidbody2D _rigidBody;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rendererToFlip.flipX = (_rigidBody.velocity.x < 0);
    }
}
