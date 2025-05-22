using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    private int _maxHealth;
    private int _injuredHealthPercentLimit;
    private int _health;
    private bool _isDead;

    public Health(int maxHealth, int injuredHealthPercentLimit)
    {
        _maxHealth = maxHealth;
        _injuredHealthPercentLimit = injuredHealthPercentLimit;

        _health = _maxHealth;
    }

    public int CurrentHealth => _health;
    public int MaxHealth => _maxHealth;
    public bool IsDead => _isDead;
    public bool IsInjured => _health <= _injuredHealthPercentLimit * _maxHealth / 100;

    public bool TryTakeDamage(int damage)
    {
        if (damage <= 0 || _isDead)
            return false;

        _health -= damage;

        Debug.Log($"Health: {_health}");

        if (_health <= 0)
            Die();

        return true;
    }

    private void Die()
    {
        _isDead = true;
        Debug.Log("Character is dead");
    }
}
