using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private const int LeftMouseButton = 0;
    private const int RightMouseButton = 1;

    [SerializeField] private int _explosionRadius = 4;  
    [SerializeField] private int _explosionForce = 15;
    [SerializeField] private GameObject _explosionEffectPrefab;


    private Movable _currentMovableObject;


    private void Update()
    {
        LeftMouseButtonProcessing();
        RightMouseButtonProcessing();
    }

    private void LeftMouseButtonProcessing()
    {
        CatchMovableObject();
        MoveObject();
        ReleaseMovableObject();
    }

    private void CatchMovableObject()
    {
        if (_currentMovableObject == null && Input.GetMouseButtonDown(LeftMouseButton))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out Movable movable))
                    _currentMovableObject = movable;
            }
        }
    }
    
    private void MoveObject() 
    {
        if (_currentMovableObject != null && Input.GetMouseButton(LeftMouseButton))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
                _currentMovableObject.Move(
                    new Vector3(hit.point.x, _currentMovableObject.transform.position.y, hit.point.z)
                );
        }
    }

    private void ReleaseMovableObject()
    {
        if (Input.GetMouseButtonUp(LeftMouseButton))
            _currentMovableObject = null;
    }

    private void RightMouseButtonProcessing()
    {
        if (Input.GetMouseButtonDown(RightMouseButton))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (_explosionEffectPrefab != null)
                    Instantiate(_explosionEffectPrefab, hit.point, Quaternion.identity);

                Collider[] colliders = Physics.OverlapSphere(hit.point, _explosionRadius);
                
                foreach (Collider collider in colliders)
                {
                    if (collider.TryGetComponent<Explosable>(out Explosable explosable))
                        explosable.Explode(hit.point, _explosionForce);
                }
            }
        }
    }
}
