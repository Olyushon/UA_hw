using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController
{
    private IGrabable _currentGrabableObject;

    public GrabController() {}

    public void GrabObject()
    {
        if (_currentGrabableObject == null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out IGrabable grabable))
                {
                    _currentGrabableObject = grabable;
                    _currentGrabableObject.OnGrab();
                }
            }
        }
    }
    
    public void MoveObject() 
    {
        if (_currentGrabableObject != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
                _currentGrabableObject.Move(
                    new Vector3(hit.point.x, _currentGrabableObject.Transform.position.y, hit.point.z)
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
