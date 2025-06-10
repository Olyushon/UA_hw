using System;
using UnityEngine;

namespace Module29_30 {

    [Serializable]
    public class DragonSettings : EnemySettings
    {
        [SerializeField] private int _flySpeed;

        public int FlySpeed => _flySpeed;
    }
}
