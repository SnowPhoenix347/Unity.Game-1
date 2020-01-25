using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private Transform _platform;
    [SerializeField] private BoxCollider2D _boxCollider2D;
    [SerializeField] private Transform player;

    private Transform[] _platforms;
    private float _distanceGenerate = 3f;

    private void Start()
    {
        _platforms = GeneratePlatforms(_platforms);
    }

    private void Update()
    {
        MoveLastPlatform();
    }

    private void MoveLastPlatform()
    {
        if (Vector2.Distance(player.position, _platforms[0].position) < _distanceGenerate)
        {
            _platforms[1].position = new Vector2(_platforms[0].position.x + _boxCollider2D.size.x, 0);

            Transform tempPlatform;
            tempPlatform = _platforms[0];
            _platforms[0] = _platforms[1];
            _platforms[1] = tempPlatform;
        }
    }

    private Transform[] GeneratePlatforms(Transform[] platforms)
    {
        Transform[] tempPlatforms = new Transform[2];
        Vector2 _childPlatformPosition = new Vector2(_platform.position.x + _boxCollider2D.size.x, _platform.position.y);
        tempPlatforms[0] = Instantiate(_platform, _childPlatformPosition, Quaternion.identity);
        tempPlatforms[1] = _platform;

        return tempPlatforms;
    }
}
