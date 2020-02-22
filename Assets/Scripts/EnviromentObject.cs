using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnviromentObject
{
    public GameObject Template => _template;
    public int TemplatesCount => _templatesCount;
    [SerializeField] private GameObject _template;
    [SerializeField] private int _templatesCount;
}