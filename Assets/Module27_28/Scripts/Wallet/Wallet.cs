using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Wallet
{
    public event Action<CurrencyType, int> CurrencyAmountChanged;

    private Dictionary<CurrencyType, int> _currenciesAmount;
    public Dictionary<CurrencyType, int> CurrenciesAmount => _currenciesAmount;


    public Wallet(Dictionary<CurrencyType, int> currenciesAmount)
    {
        _currenciesAmount = currenciesAmount;
    }

    public void Add(CurrencyType currencyType, int amount)
    {
        if (amount < 0)
            return;

        if (_currenciesAmount.ContainsKey(currencyType))
            _currenciesAmount[currencyType] += amount;
        else
            _currenciesAmount.Add(currencyType, amount);

        CurrencyAmountChanged?.Invoke(currencyType, _currenciesAmount[currencyType]);
    }

    public void Spend(CurrencyType currencyType, int amount)
    {
        if (amount < 0)
            return;

        if (_currenciesAmount.ContainsKey(currencyType))
        {
            _currenciesAmount[currencyType] -= amount;

            if (_currenciesAmount[currencyType] < 0)
                _currenciesAmount[currencyType] = 0;

            CurrencyAmountChanged?.Invoke(currencyType, _currenciesAmount[currencyType]);
        }
    }

}
