using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayerMask;

    private BoxCollider2D _boxCollider2D;

    private void Start()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    public bool IsGrounded()
    {
        Collider2D rayCastCollider2D = Physics2D.OverlapBox(_boxCollider2D.bounds.center, _boxCollider2D.bounds.size, 0f, _groundLayerMask);

        return rayCastCollider2D != null;
    }
}
