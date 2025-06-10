using System;
using UnityEngine;

namespace Module29_30 {

    [Serializable]
    public class ElfSettings : EnemySettings
    {
        [SerializeField] private int _magicPower;

        public int MagicPower => _magicPower;
    }
}