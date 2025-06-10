using UnityEngine;

namespace Module29_30 {
    public abstract class Enemy : MonoBehaviour
    {
        protected void ShowInfo(string info)
        {
            Debug.Log(info);
        }
    }
}

