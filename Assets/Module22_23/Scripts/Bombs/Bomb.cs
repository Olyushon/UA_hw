using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private int _damage = 10;
    [SerializeField] private float _radius = 2f;
    [SerializeField] private float _activationTime = 1f;

    private bool _isActivated;
    private bool _explodingInProcess;
    private float _timer;
    private BombView _bombView;

    private void Awake()
    {
        gameObject.GetComponent<SphereCollider>().radius = _radius;
        _timer = _activationTime;
        _bombView = GetComponent<BombView>();
    }

    private void Update()
    {
        if (_explodingInProcess)
            return;

        if (_isActivated)
            _timer -= Time.deltaTime;

        if (_timer <= 0)
            Explode();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IBombActivator bombActivator))
            Activate();
    }

    private void Activate()
    {
        _isActivated = true;
    }

    private void Explode()
    {
        _explodingInProcess = true;
        
        _bombView.MakeExplosionEffect();

        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out IDamagable damagable))
                damagable.TakeDamage(_damage);
        }

        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
