using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnDeath : MonoBehaviour
{
    [SerializeField] private EnvironmentTrigger _trigger;

    private void OnEnable()
    {
        _trigger.TrapTriggered += OnTrapTriggered;
    }

    private void OnDisable()
    {
        _trigger.TrapTriggered += OnTrapTriggered;
    }

    private void OnTrapTriggered()
    {
        SceneManager.LoadScene(1);
    }
}