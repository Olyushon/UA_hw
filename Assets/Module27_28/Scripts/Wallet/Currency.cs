using UnityEngine;
using System;

public class Currency
{
    private ReactableVariable<int> _amount;

    public Currency(int amount)
    {
        _amount = new ReactableVariable<int>(amount);
    }

    public IReactable<int> Amount => _amount;


    public void Add(int amount)
    {
        if (amount < 0)
        {
            Debug.LogError("Amount is less than 0");
            return;
        }

        _amount.Value += amount;
    }

    public void Spend(int amount)
    {
        if (amount < 0)
        {
            Debug.LogError("Amount is less than 0");
            return;
        }

        _amount.Value -= amount;

        if (_amount.Value < 0)
            _amount.Value = 0;  

    }
}
