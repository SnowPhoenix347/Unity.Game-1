using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _gameObjects;
    [SerializeField] private int _randomSetting = 3;
    [SerializeField] private int _coinsCount = 5;
    [SerializeField] private float _mixSpawnTime = 1f;
    [SerializeField] private float _maxSpawnTime = 4f;

    private void Start()
    {
        StartCoroutine("Spawn", _gameObjects);
    }

    private IEnumerator Spawn(GameObject[] gameObjects)
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(_mixSpawnTime, _maxSpawnTime));
            int spawnRandom = Random.Range(0, 10);

            if  (spawnRandom > _randomSetting)
            {
                SpawnTraps(gameObjects); 
            }
            else 
            {
                StartCoroutine("SpawnCoins", gameObjects);
            }
        }
    }

    private IEnumerator SpawnCoins(GameObject[] gameObjects)
    {
        for (int i = 0; i < _coinsCount; i++)
        {
            yield return new WaitForSeconds(0.1f);
            Instantiate(gameObjects[1], new Vector2 (transform.position.x, 1f), transform.rotation);
        }
    }

    private void SpawnTraps(GameObject[] gameObjects) => Instantiate(gameObjects[0], new Vector2(transform.position.x, 0f), transform.rotation);
}
