using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TemplateCheckerOnEntering : MonoBehaviour
{
    public UnityEvent OnCoinCollected;
    public UnityEvent OnTrapTriggered;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Coin>())
        {
            OnCoinCollected.Invoke();
            Destroy(other.gameObject);
        }
        else if(other.GetComponent<Trap>())
        {
            OnTrapTriggered.Invoke();
        }
    }
}
