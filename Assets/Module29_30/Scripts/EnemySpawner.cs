using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Module29_30 {

    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Dragon _dragonPrefab;
        [SerializeField] private Elf _elfPrefab;
        [SerializeField] private Ork _orkPrefab;

        [SerializeField] private int _spawnPositionLimit = 10;

        public void SpawnEnemyBy(EnemySettings enemySettings)
        {
            switch (enemySettings)
            {
                case DragonSettings dragonSettings:
                    SpawnDragon(dragonSettings);
                    break;

                case ElfSettings elfSettings:
                    SpawnElf(elfSettings);
                    break;

                case OrkSettings orkSettings:
                    SpawnOrk(orkSettings);
                    break;

                default:
                    Debug.LogError("Unknown enemy type");
                    break;
            }
        }

        private void SpawnDragon(DragonSettings dragonSettings)
        {
            Dragon dragon = Spawn(_dragonPrefab);
            dragon.Initialize(dragonSettings);
        }

        private void SpawnElf(ElfSettings elfSettings)
        {
            Elf elf = Spawn(_elfPrefab);
            elf.Initialize(elfSettings);
        }

        private void SpawnOrk(OrkSettings orkSettings)
        {
            Ork ork = Spawn(_orkPrefab);
            ork.Initialize(orkSettings);
        }
        
        private T Spawn<T>(T prefab) where T : Enemy
        {
            return Instantiate(prefab, GetRandomSpawnPosition(), GetRandomSpawnRotation());
        }

        private Vector3 GetRandomSpawnPosition()
        {
            return new Vector3(Random.Range(-_spawnPositionLimit, _spawnPositionLimit), 0, Random.Range(-_spawnPositionLimit, _spawnPositionLimit));
        }

        private Quaternion GetRandomSpawnRotation()
        {
            return Quaternion.Euler(0, Random.Range(0, 360), 0);
        }
    }
}
