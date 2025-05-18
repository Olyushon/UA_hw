using UnityEngine;

public class Explosable : MonoBehaviour
{
    public void Explode(Vector3 explosionCenter, float explosionForce)
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
