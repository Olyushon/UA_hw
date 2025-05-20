using UnityEngine;

public class Game : MonoBehaviour
{
    private const int LeftMouseButton = 0;
    private const int RightMouseButton = 1;

    [SerializeField] private int _explosionRadius = 4;  
    [SerializeField] private int _explosionForce = 15;
    [SerializeField] private GameObject _explosionEffectPrefab;

    private GrabController _grabController;
    private ExploseController _exploseController;

    private void Awake()
    {
        _grabController = new GrabController(LeftMouseButton);
        _exploseController = new ExploseController(RightMouseButton, _explosionRadius, _explosionForce, _explosionEffectPrefab);
    }

    private void Update()
    {
        _grabController.Update(Time.deltaTime);
        _exploseController.Update(Time.deltaTime);
    }
}
