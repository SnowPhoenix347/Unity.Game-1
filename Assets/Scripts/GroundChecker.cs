using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private BoxCollider2D _boxCollider2D;

    private void Start()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    public bool IsGrounded(LayerMask groundLayerMask)
    {
        RaycastHit2D rayCastHit2D = Physics2D.BoxCast(_boxCollider2D.bounds.center, _boxCollider2D.bounds.size, 0f, Vector2.down, 0.1f, groundLayerMask);

        return rayCastHit2D.collider != null;
    }
}
