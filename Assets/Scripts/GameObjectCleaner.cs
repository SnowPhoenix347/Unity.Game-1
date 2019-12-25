using UnityEngine;

public class GameObjectCleaner : MonoBehaviour
{
    [SerializeField] private float _liveTime = 3f;

    private void Start() => Destroy(gameObject, _liveTime);
}
