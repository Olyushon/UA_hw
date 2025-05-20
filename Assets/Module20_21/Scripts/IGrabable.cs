using UnityEngine;

public interface IGrabable
{
    Transform Transform { get; }

    void OnGrab();

    void Move(Vector3 position);

    void OnRelease();
}
