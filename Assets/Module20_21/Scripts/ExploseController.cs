using UnityEngine;

public class ExploseController
{
    private int _explosionRadius;
    private int _explosionForce;
    private GameObject _explosionEffectPrefab;

    public ExploseController(int explosionRadius, int explosionForce, GameObject explosionEffectPrefab)
    {
        _explosionRadius = explosionRadius;
        _explosionForce = explosionForce;
        _explosionEffectPrefab = explosionEffectPrefab;
    }

    public void Explose()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (_explosionEffectPrefab != null)
                Object.Instantiate(_explosionEffectPrefab, hit.point, Quaternion.identity);

            Collider[] colliders = Physics.OverlapSphere(hit.point, _explosionRadius);
            
            foreach (Collider collider in colliders)
            {
                if (collider.TryGetComponent<IExploseable>(out IExploseable explosable))
                    explosable.OnExplose(hit.point, _explosionForce);
            }
        }
    }
}
