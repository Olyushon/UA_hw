using System;
using UnityEngine;

namespace Module29_30 {

    [Serializable]
    public class OrkSettings : EnemySettings
    {
        [SerializeField] private int _attackPower;

        public int AttackPower => _attackPower;
    }
}