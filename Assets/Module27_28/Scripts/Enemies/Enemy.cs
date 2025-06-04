using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool IsDead { get; set; }

    public void Destroy()
    {
        IsDead = true;
        Destroy(gameObject);
    }
}
