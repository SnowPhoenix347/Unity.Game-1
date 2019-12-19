using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _groundLayerMask;
    private Rigidbody2D _rigidBody2D;
    private GroundChecker _groundChecker;

    private void Start()
    {
        _rigidBody2D = transform.GetComponent<Rigidbody2D>();
        _groundChecker = GetComponent<GroundChecker>();
    }
    private void FixedUpdate()
    {
        _rigidBody2D.velocity = new Vector2(_speed, _rigidBody2D.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && _groundChecker.IsGrounded(_groundLayerMask))
        {
            _rigidBody2D.velocity = Vector2.up * _jumpForce;
        }
    }
}
