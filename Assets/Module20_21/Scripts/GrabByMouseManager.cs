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
            _grabController.GrabObject();

        if (Input.GetMouseButton(_mouseButton))
            _grabController.MoveObject();

        if (Input.GetMouseButtonUp(_mouseButton))
            _grabController.ReleaseObject();
    }
}
