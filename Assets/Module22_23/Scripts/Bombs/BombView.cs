using UnityEngine;

public class BombView : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosionEffectPrefab;

    public void MakeExplosionEffect()
    {
        if (_explosionEffectPrefab != null)
        {
            Instantiate(_explosionEffectPrefab, transform.position, Quaternion.identity);
        }
    }
}
