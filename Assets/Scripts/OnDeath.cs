using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnDeath : MonoBehaviour
{
    [SerializeField] private TemplateCheckerOnEntering _checker;

    private void OnEnable()
    {
        _checker.OnTrapTriggered.AddListener(Death);
    }

    private void OnDisable()
    {
        _checker.OnTrapTriggered.RemoveListener(Death);
    }

    private void Death()
    {
        SceneManager.LoadScene(1);
    }
}