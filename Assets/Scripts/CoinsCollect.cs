using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsCollect : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 3);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
