using UnityEngine;

public class Game : MonoBehaviour
{
    private const int LeftMouseButton = 0;
    private const int RightMouseButton = 1;

    [SerializeField] private int _explosionRadius = 4;  
    [SerializeField] private int _explosionForce = 15;
    [SerializeField] private GameObject _explosionEffectPrefab;

    private GrabByMouseManager _grabByMouseManager;
    private ExploseByMouseManager _exploseByMouseManager;

    private void Awake()
    {
        _grabByMouseManager = new GrabByMouseManager(LeftMouseButton);
        _exploseByMouseManager = new ExploseByMouseManager(RightMouseButton, _explosionRadius, _explosionForce, _explosionEffectPrefab);
    }

    private void Update()
    {
        _grabByMouseManager.Update(Time.deltaTime);
        _exploseByMouseManager.Update(Time.deltaTime);
    }
}
