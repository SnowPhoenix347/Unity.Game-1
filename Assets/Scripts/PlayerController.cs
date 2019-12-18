using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _groundLayerMask;
    private Rigidbody2D _playerRigidBody2D;
    private GroundChecker _groundChecker;

    private void Start()
    {
        _playerRigidBody2D = transform.GetComponent<Rigidbody2D>();
        _groundChecker = GetComponent<GroundChecker>();
    }
    private void Update()
    {
        _playerRigidBody2D.velocity = new Vector2(_speed, _playerRigidBody2D.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && _groundChecker.IsGrounded(_groundLayerMask))
        {
            _playerRigidBody2D.velocity = Vector2.up * _jumpForce;
        }
    }
}
