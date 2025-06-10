using UnityEngine;

namespace Module29_30 {
    public class Elf : Enemy
    {
        private int _magicPower;

        public void Initialize(ElfSettings elfSettings)
        {
            _magicPower = elfSettings.MagicPower;
            ShowInfo($"Elf with magic power {_magicPower} was spawned");
        }
    }
}
