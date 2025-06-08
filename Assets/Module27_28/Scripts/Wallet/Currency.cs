using UnityEngine;
using System;

public class Currency
{
    public event Action<int> AmountChanged;
    private int _amount;

    public Currency(int amount)
    {
        _amount = amount;
    }

    public int Amount => _amount;


    public void Add(int amount)
    {
        _amount += amount;
        AmountChanged?.Invoke(_amount);
    }

    public void Spend(int amount)
    {
        _amount -= amount;

        if (_amount < 0)
            _amount = 0;

        AmountChanged?.Invoke(_amount);
    }
}
