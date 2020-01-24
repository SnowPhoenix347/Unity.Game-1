using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TemplateCheckerOnEntering : MonoBehaviour
{
    [SerializeField] private UnityEvent _onCoinCollected;
    [SerializeField] private UnityEvent _onTrapTriggered;

    public event UnityAction OnCoinCollected
    {
        add => _onCoinCollected.AddListener(value);
        remove => _onCoinCollected.RemoveListener(value);
    }
    public event UnityAction OnTrapTriggered
    {
        add => _onTrapTriggered.AddListener(value);
        remove => _onTrapTriggered.RemoveListener(value);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Coin>())
        {
            _onCoinCollected.Invoke();
            Destroy(other.gameObject);
        }
        else if(other.GetComponent<Trap>())
        {
            _onTrapTriggered.Invoke();
        }
    }
}
