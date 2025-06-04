using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemiesExample : MonoBehaviour
{
    [SerializeField] private EnemiesService _enemiesService;
    [SerializeField] private Enemy _enemyPrefab;

    private void Awake()
    {
        _enemiesService = new EnemiesService();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Enemy enemy = CreateEnemy();
            enemy.IsDead = RandomBool();

            _enemiesService.AddEnemy(enemy, () => enemy.IsDead);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Enemy enemy = CreateEnemy();
            float creationTime = Time.time;

            _enemiesService.AddEnemy(enemy, () => Time.time - creationTime >= 2f);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Enemy enemy = CreateEnemy();

            _enemiesService.AddEnemy(enemy, () => _enemiesService.EnemiesCount > 10);
        }
    }

    private void FixedUpdate()
    {
        _enemiesService.FixedUpdate(Time.fixedDeltaTime);
    }

    private bool RandomBool()
    {
        return UnityEngine.Random.Range(0, 10) < 5;
    }

    private Enemy CreateEnemy()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
        
        return Instantiate(_enemyPrefab, randomPosition, Quaternion.identity);
    }
}
