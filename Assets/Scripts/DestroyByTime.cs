using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    [SerializeField] private float _liveTime = 3f;

    private void Start() => Destroy(gameObject, _liveTime);
}
