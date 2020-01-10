using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(GroundChecker))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 0.3f;
    [SerializeField] private float _jumpForce = 7f;

    private Rigidbody2D _rigidBody2D;
    private GroundChecker _groundChecker;

    private void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _groundChecker = GetComponent<GroundChecker>();
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * _speed);
        if (Input.GetKeyDown(KeyCode.Space) && _groundChecker.IsGrounded())
        {
            Jump();
        }
    }
    private void Jump()
    {
        _rigidBody2D.velocity = Vector2.up * _jumpForce;
    }
}
