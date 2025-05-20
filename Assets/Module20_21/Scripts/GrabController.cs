using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController
{
    private int _mouseButton;
    private IGrabable _currentGrabableObject;

    public GrabController(int mouseButton)
    {
        _mouseButton = mouseButton;
    }

    public void Update(float deltaTime)
    {
        GrabObject();
        MoveObject();
        ReleaseObject();
    }

    private void GrabObject()
    {
        if (_currentGrabableObject == null && Input.GetMouseButtonDown(_mouseButton))
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
    
    private void MoveObject() 
    {
        if (_currentGrabableObject != null && Input.GetMouseButton(_mouseButton))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
                _currentGrabableObject.Move(
                    new Vector3(hit.point.x, _currentGrabableObject.Transform.position.y, hit.point.z)
                );
        }
    }

    private void ReleaseObject()
    {
        if (Input.GetMouseButtonUp(_mouseButton))
        {
            _currentGrabableObject.OnRelease();
            _currentGrabableObject = null;
        }
    }
}
