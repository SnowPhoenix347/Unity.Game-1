using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _templates;
    [SerializeField] private int _randomSetting = 3;
    [SerializeField] private int _coinsCount = 5;
    [SerializeField] private float _minSpawnTime = 1f;
    [SerializeField] private float _maxSpawnTime = 4f;

    private void Start()
    {
        StartCoroutine(SpawnByTime(_templates));
    }

    private IEnumerator SpawnByTime(GameObject[] templates)
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(_minSpawnTime, _maxSpawnTime));
            SpawnSelecter(templates);
        }
    }

    private void SpawnSelecter(GameObject[] templates)
    {
        int spawnRandom = Random.Range(0, 10);

        if (spawnRandom > _randomSetting)
        {
            Spawn(templates, 0, 0f);
        }
        else
        {
            StartCoroutine(LineSpawn(templates, _coinsCount));
        }
    }

    private IEnumerator LineSpawn(GameObject[] templates, int lineLenght)
    {
        for (int i = 0; i < lineLenght; i++)
        {
            yield return new WaitForSeconds(0.1f);
            Spawn(templates, 1, 1f);
        }
    }

    private void Spawn(GameObject[] templates, int IDtemplate, float heightSpawn)
    {
        Instantiate(templates[IDtemplate], new Vector2(transform.position.x, heightSpawn), transform.rotation);
    }
}
