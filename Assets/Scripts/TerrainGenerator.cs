using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private Transform _platform;
    [SerializeField] private BoxCollider2D _boxCollider2D;
    [SerializeField] private Transform player;
    private Transform[] _platforms;
    private float _distanceGenerat = 3f;

    private void Start()
    {
        _platforms = GeneratePlatforms(_platforms);
    }

    private void Update()
    {
        MovePlatforms();
    }

    private void MovePlatforms()
    {
        if (Vector2.Distance(player.position, _platforms[0].position) < _distanceGenerat)
        {
            _platforms[1].position = new Vector2(_platforms[0].position.x + _boxCollider2D.size.x, 0);
        }
        if (Vector2.Distance(player.position, _platforms[1].position) < _distanceGenerat)
        {
            _platforms[0].position = new Vector2(_platforms[1].position.x + _boxCollider2D.size.x, 0);
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
