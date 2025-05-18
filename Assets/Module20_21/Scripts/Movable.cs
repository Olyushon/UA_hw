using UnityEngine;

public class Movable : MonoBehaviour
{
    public void Move(Vector3 direction)
    {
        transform.position = direction;
    }
}
