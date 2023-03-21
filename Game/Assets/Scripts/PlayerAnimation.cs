using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Animator _animator;
    private SpriteRenderer _renderer;
    private Rigidbody2D _rigidBody;
    private bool isFlipped = false;//manages direction of player when idle

    [SerializeField] private AnimationState _state = AnimationState.Idle;
    [HideInInspector] public AnimationState State { get { return _state; } set { _state = value; } }

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _renderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (_state == AnimationState.Running)//if player is running
            _animator.SetBool("IsRunning", true);
        else
            _animator.SetBool("IsRunning", false);

        if (_state == AnimationState.Falling)//if player is falling
            _animator.SetBool("IsFalling", true);
        else
            _animator.SetBool("IsFalling", false);

        if (Input.GetAxisRaw("Horizontal") != 0)//GetAxisRaw makes for snappier turning
        {
            _renderer.flipX = (_rigidBody.velocity.x < 0);//simple flip sprite based on velocity(to make it look the direction of movement)
            if (_rigidBody.velocity.x != 0)
                isFlipped = _renderer.flipX;//store direction the player ends movement facing
        }
        else
        {
            _renderer.flipX = isFlipped;//faces player in the correct direction at end of movement
        }
    }
}

[System.Serializable]
public enum AnimationState
{
    Idle,
    Running,
    Falling,
}
