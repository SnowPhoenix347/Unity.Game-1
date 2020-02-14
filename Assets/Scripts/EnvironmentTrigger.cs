using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentTrigger : MonoBehaviour
{
    public event Action CoinCollecting;
    public event Action TrapTriggered;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Coin>())
        {
            CoinCollecting.Invoke();
            Destroy(other.gameObject);
        }
        else if(other.GetComponent<Trap>())
        {
            TrapTriggered.Invoke();
        }
    }
}
