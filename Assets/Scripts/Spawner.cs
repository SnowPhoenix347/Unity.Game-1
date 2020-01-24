using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _coin;
    [SerializeField] private GameObject _trap;
    [SerializeField] private int _spawnChange = 30;
    [SerializeField] private int _coinsLineLength = 5;
    [SerializeField] private float _minSpawnTime = 1f;
    [SerializeField] private float _maxSpawnTime = 4f;
    [SerializeField] private float distanceBetweenTemplates = 2f;

    private void Start()
    {
        StartCoroutine(SpawnByTime(_coin, _trap));
    }

    private IEnumerator SpawnByTime(GameObject coin, GameObject trap)
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(_minSpawnTime, _maxSpawnTime));
            SpawnRandomTemplate(coin, trap);
        }
    }

    private void SpawnRandomTemplate(GameObject coin, GameObject trap)
    {
        if (Random.Range(0, 100) > _spawnChange)
        {
            Spawn(trap, 0f);
        }
        else
        {
            SpawnTemplate(coin, _coinsLineLength, 1f);
        }
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

    private void Spawn(GameObject template, float heightSpawn)
    {
        Instantiate(template, new Vector2(transform.position.x, heightSpawn), transform.rotation);
    }

    private void Spawn(GameObject template, float heightSpawn, float spawnPositionX)
    {
        Instantiate(template, new Vector2(spawnPositionX, heightSpawn), transform.rotation);
    }

    #region MonoBehavior
    private void OnValidate()
    {
        if (_spawnChange < 0) _spawnChange = 0;
        else if (_spawnChange > 100) _spawnChange = 100;
    }
    #endregion
}