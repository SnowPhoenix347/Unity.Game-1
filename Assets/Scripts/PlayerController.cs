using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 0.3f;
    [SerializeField] private float _jumpForce = 7f;
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
        transform.Translate(Vector2.right * _speed);
        if (Input.GetKeyDown(KeyCode.Space) && _groundChecker.IsGrounded(_groundLayerMask))
        {
            _rigidBody2D.velocity = Vector2.up * _jumpForce;
        }
    }
}
