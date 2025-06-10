using UnityEngine;

namespace Module29_30 {
    public class Ork : Enemy
    {
        private int _attackPower;

        public void Initialize(OrkSettings orkSettings)
        {
            _attackPower = orkSettings.AttackPower;
            ShowInfo($"Ork with attack power {_attackPower} was spawned");
        }
    }
}
