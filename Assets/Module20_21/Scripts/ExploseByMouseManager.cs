using UnityEngine;

public class ExploseByMouseManager
{
    private int _mouseButton;
    private ExploseController _exploseController;

    public ExploseByMouseManager(int mouseButton, int explosionRadius, int explosionForce, GameObject explosionEffectPrefab)
    {
        _mouseButton = mouseButton;
        _exploseController = new ExploseController(explosionRadius, explosionForce, explosionEffectPrefab);
    }

    public void Update(float deltaTime)
    {
        if (Input.GetMouseButtonDown(_mouseButton))
            _exploseController.Explose();
    }
}
