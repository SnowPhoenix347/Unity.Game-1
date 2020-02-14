using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _templates;
    [SerializeField] private int[] _templatesLength;
    [SerializeField] private float _minSpawnTime = 1f;
    [SerializeField] private float _maxSpawnTime = 4f;
    [SerializeField] private float distanceBetweenTemplates = 2f;

    private void Start()
    {
        StartCoroutine(SpawnByTime());
    }

    private IEnumerator SpawnByTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(_minSpawnTime, _maxSpawnTime));
            SpawnRandomTemplate(_templates, _templatesLength);
        }
    }

    private void SpawnRandomTemplate(GameObject[] templates, int[] templatesLength)
    {
        int templateIndex = Random.Range(0, templates.Length);
        SpawnTemplate(templates[templateIndex], _templatesLength[templateIndex], 1f);
    }

    private void SpawnTemplate(GameObject template, int countTemplates, float heightSpawn)
    {
        float spawnPositionX = transform.position.x;
        for (int i = 0; i < countTemplates; i++)
        {
            spawnPositionX += distanceBetweenTemplates;
            Spawn(template, heightSpawn, spawnPositionX);
        }
    }


    private void Spawn(GameObject template, float heightSpawn, float spawnPositionX)
    {
        Instantiate(template, new Vector2(spawnPositionX, heightSpawn), transform.rotation);
    }

    #region MonoBehavior
    private void OnValidate()
    {
        if (_templates.Length > _templatesLength.Length)
        {
            int[] tempArr = new int[_templates.Length];
            System.Array.Copy(_templatesLength, tempArr, _templatesLength.Length);
            _templatesLength = tempArr;
        }
        else if (_templates.Length < _templatesLength.Length)
        {
            int[] tempArr = new int[_templates.Length];
            System.Array.Copy(_templatesLength, tempArr, _templates.Length);
            _templatesLength = tempArr;
        }
    }
    #endregion
}