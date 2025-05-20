using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, IGrabable, IExploseable
{
    public Transform Transform => transform;
    
    public void OnGrab()
    {
        Debug.Log("OnGrab");
    }

    public void Move(Vector3 position)
    {
        transform.position = position;
    }

    public void OnRelease()
    {
        Debug.Log("OnRelease");
    }

    public void OnExplose(Vector3 explosionCenter, float explosionForce)
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        if (rigidbody != null)
        {
            Vector3 direction = (transform.position - explosionCenter).normalized;
            float distance = Vector3.Distance(transform.position, explosionCenter);
            float force = explosionForce / distance;

            rigidbody.AddForce(direction * force, ForceMode.Impulse);
            
            rigidbody.AddTorque(GetRandomRotation() * force, ForceMode.Impulse);
        }
    }

    private Vector3 GetRandomRotation()
    {
        return new Vector3(
            Random.Range(-1, 1),
            Random.Range(-1, 1),
            Random.Range(-1, 1)
        ).normalized;
    }
}
