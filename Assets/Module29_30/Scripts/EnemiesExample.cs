using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Module29_30 {

    public class EnemiesExample : MonoBehaviour
    {
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private int _eachTypeEnemyCount = 3;

        [SerializeField] private List<DragonSettings> _dragonSettingsList;
        [SerializeField] private List<ElfSettings> _elfSettingsList;
        [SerializeField] private List<OrkSettings> _orkSettingsList;


        private void Start()
        {
            SpawnEnemiesBy(_dragonSettingsList);
            SpawnEnemiesBy(_elfSettingsList);
            SpawnEnemiesBy(_orkSettingsList);
        }

        private void SpawnEnemiesBy<T>(List<T> settingsList) where T : EnemySettings
        {
            for (int i = 0; i < _eachTypeEnemyCount; i++)
            {
                _enemySpawner.SpawnEnemyBy(GetRandomEnemySettings(settingsList));
            }
        }

        private T GetRandomEnemySettings<T>(List<T> settingsList) where T : EnemySettings
        {
            return settingsList[Random.Range(0, settingsList.Count)];
        }
    }
}
