using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalRotator
{
    private Transform _transform;

    private float _rotationSpeed;

    private Vector3 _currentDirection;

    public DirectionalRotator(Transform transform, float rotationSpeed)
    {
        _transform = transform;
        _rotationSpeed = rotationSpeed;
    }

    public Quaternion CurrentRotation => _transform.rotation;

    public void SetInputDirection(Vector3 direction) => _currentDirection = direction;

    public void Update(float deltaTime)
    {
        if (_currentDirection.magnitude < 0.05f)
            return;

        Quaternion targetRotation = Quaternion.LookRotation(_currentDirection.normalized);

        float rotationStep = _rotationSpeed * deltaTime;

        _transform.rotation = Quaternion.RotateTowards(_transform.rotation, targetRotation, rotationStep);
    }
}
