using UnityEngine;

namespace Module29_30 {
    public class Dragon : Enemy
    {
        private int _flySpeed;

        public void Initialize(DragonSettings dragonSettings)
        {
            _flySpeed = dragonSettings.FlySpeed;
            ShowInfo($"Dragon with fly speed {_flySpeed} was spawned");
        }
    }
}
