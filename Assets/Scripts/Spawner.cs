using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private EnviromentObject[] _enviromentObjects;
    [SerializeField] private float _minSpawnTime = 1f;
    [SerializeField] private float _maxSpawnTime = 4f;
    [SerializeField] private float _distanceBetweenTemplates = 2f;

    private void Start()
    {
        StartCoroutine(SpawnByTime());
    }

    private IEnumerator SpawnByTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(_minSpawnTime, _maxSpawnTime));
            SpawnRandomTemplate(_enviromentObjects);
        }
    }

    private void SpawnRandomTemplate(EnviromentObject[] templates)
    {
        int templateIndex = Random.Range(0, _enviromentObjects.Length);
        SpawnTemplate(templates[templateIndex].Template, templates[templateIndex].TemplatesCount, 1f);
    }

    private void SpawnTemplate(GameObject template, int countTemplates, float heightSpawn)
    {
        float spawnPositionX = transform.position.x;
        for (int i = 0; i < countTemplates; i++)
        {
            spawnPositionX += _distanceBetweenTemplates;
            Spawn(template, heightSpawn, spawnPositionX);
        }
    }

    private void Spawn(GameObject template, float heightSpawn, float spawnPositionX)
    {
        Instantiate(template, new Vector2(spawnPositionX, heightSpawn), transform.rotation);
    }
}