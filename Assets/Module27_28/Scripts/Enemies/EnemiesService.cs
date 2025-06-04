using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesService
{
    private List<Enemy> _enemies;
    private Dictionary<Enemy, DestroyCause> _enemiesDestroyCauses;

    public int EnemiesCount => _enemies.Count;

    public EnemiesService()
    {
        _enemies = new List<Enemy>();
        _enemiesDestroyCauses = new Dictionary<Enemy, DestroyCause>();
    }

    public void AddEnemy(Enemy enemy, DestroyCause destroyCause)
    {
        _enemies.Add(enemy);
        _enemiesDestroyCauses.Add(enemy, destroyCause);
    }

    public void FixedUpdate(float deltaTime)
    {
        for (int i = _enemies.Count - 1; i >= 0; i--)
        {
            Enemy enemy = _enemies[i];

            if (IsShouldBeDestroyed(enemy))
                RemoveAndDestroyEnemy(enemy);
        }

        Debug.Log("Enemies count: " + _enemies.Count);
    }

    private bool IsShouldBeDestroyed(Enemy enemy)
    {
        return _enemiesDestroyCauses[enemy].Invoke();
    }

    private void RemoveAndDestroyEnemy(Enemy enemy)
    {
        _enemies.Remove(enemy);
        _enemiesDestroyCauses.Remove(enemy);
        enemy.Destroy();
    }
}
