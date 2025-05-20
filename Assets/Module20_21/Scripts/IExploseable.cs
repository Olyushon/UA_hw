using UnityEngine;

public interface IExploseable
{
    void OnExplose(Vector3 explosionCenter, float explosionForce);
}
