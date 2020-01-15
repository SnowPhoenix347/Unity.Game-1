using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _templates;
    [SerializeField] private int _spawnChange = 30;
    [SerializeField] private int _coinsLineLength = 5;
    [SerializeField] private float _minSpawnTime = 1f;
    [SerializeField] private float _maxSpawnTime = 4f;
    [SerializeField] private float distanceBetweenTemplates = 2f;

    private void Start()
    {
        StartCoroutine(SpawnByTime(_templates));
    }

    private IEnumerator SpawnByTime(GameObject[] templates)
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(_minSpawnTime, _maxSpawnTime));
            SpawnRandomTemplate(templates);
        }
    }

    private void SpawnRandomTemplate(GameObject[] templates)
    {
        if (Random.Range(0, 100) > _spawnChange)
        {
            Spawn(templates, 0, 0f);
        }
        else
        {
            SpawnSomeTemplates(templates, _coinsLineLength, 1, 1f);
        }
    }

    private void SpawnSomeTemplates(GameObject[] templates, int countTemplates, int IDtemplate, float heightSpawn)
    {
        float spawnPositionX = transform.position.x;
        for (int i = 0; i < countTemplates; i++)
        {
            spawnPositionX += distanceBetweenTemplates;
            Spawn(templates, IDtemplate, heightSpawn, spawnPositionX);
        }
    }

    private void Spawn(GameObject[] templates, int IDtemplate, float heightSpawn)
    {
        Instantiate(templates[IDtemplate], new Vector2(transform.position.x, heightSpawn), transform.rotation);
    }

    private void Spawn(GameObject[] templates, int IDtemplate, float heightSpawn, float spawnPositionX)
    {
        Instantiate(templates[IDtemplate], new Vector2(spawnPositionX, heightSpawn), transform.rotation);
    }

    #region MonoBehavior
    private void OnValidate()
    {
        if (_spawnChange < 0) _spawnChange = 0;
        else if (_spawnChange > 100) _spawnChange = 100;
    }
    #endregion
}