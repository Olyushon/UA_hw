using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController
{
    private IGrabable _currentGrabableObject;

    public GrabController() {}

    public void GrabObject(GameObject gameObject)
    {
        if (gameObject.TryGetComponent(out IGrabable grabable))
        {
            _currentGrabableObject = grabable;
            _currentGrabableObject.OnGrab();
        }
    }

    public void MoveObjectTo(Vector3 position) 
    {
        if (_currentGrabableObject != null)
        {
            _currentGrabableObject.Move(
                new Vector3(position.x, _currentGrabableObject.Transform.position.y, position.z)
            );
        }
    }
    
    public void ReleaseObject()
    {
        if (_currentGrabableObject != null)
        {
            _currentGrabableObject.OnRelease();
            _currentGrabableObject = null;
        }
    }
}
