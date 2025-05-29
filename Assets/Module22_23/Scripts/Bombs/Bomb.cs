using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private int _damage = 10;
    [SerializeField] private float _radius = 2f;
    [SerializeField] private float _explosionTime = 1f;

    private BombView _bombView;
    private BombAudio _bombAudio;
    private Coroutine _explodeCoroutine;

    private void Awake()
    {
        gameObject.GetComponent<SphereCollider>().radius = _radius;
        _bombView = GetComponent<BombView>();
        _bombAudio = GetComponent<BombAudio>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IBombActivator bombActivator) && _explodeCoroutine == null)
            _explodeCoroutine = StartCoroutine(ExplodeCoroutine());
    }

    private IEnumerator ExplodeCoroutine()
    {
        float time = 0;

        while (time < _explosionTime)
        {
            time += Time.deltaTime;
            yield return null;
        }

        Explode();
    }

    private void Explode()
    {
        _bombView.MakeExplosionEffect();
        _bombAudio.PlayExplosionSound();

        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out IDamagable damagable))
                damagable.TakeDamage(_damage);
        }

        _explodeCoroutine = null;
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
