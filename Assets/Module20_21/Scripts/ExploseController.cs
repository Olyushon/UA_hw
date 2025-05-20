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

    public void ExploseAt(Vector3 position)
    {
        if (_explosionEffectPrefab != null)
            Object.Instantiate(_explosionEffectPrefab, position, Quaternion.identity);

        Collider[] colliders = Physics.OverlapSphere(position, _explosionRadius);
        
        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent<IExploseable>(out IExploseable explosable))
                explosable.OnExplose(position, _explosionForce);
        }
    }
}
