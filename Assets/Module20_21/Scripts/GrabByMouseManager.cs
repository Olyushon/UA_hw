using UnityEngine;

public class GrabByMouseManager
{
    private int _mouseButton;
    private GrabController _grabController;

    public GrabByMouseManager(int mouseButton)
    {
        _mouseButton = mouseButton;
        _grabController = new GrabController();
    }

    public void Update(float deltaTime)
    {
        if (Input.GetMouseButtonDown(_mouseButton))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit) && hit.collider.TryGetComponent<IGrabable>(out IGrabable grabable))
                _grabController.GrabObject(grabable);
        }

        if (Input.GetMouseButton(_mouseButton))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
                _grabController.MoveObjectTo(hit.point);
        }

        if (Input.GetMouseButtonUp(_mouseButton))
            _grabController.ReleaseObject();
    }
}
