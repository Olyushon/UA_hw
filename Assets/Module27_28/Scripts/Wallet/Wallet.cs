using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet
{
    private Dictionary<CurrencyType, Currency> _currenciesAmount;


    public Wallet(Dictionary<CurrencyType, Currency> currenciesAmount)
    {
        _currenciesAmount = currenciesAmount;
    }

    public IReadOnlyDictionary<CurrencyType, Currency> CurrenciesAmount => _currenciesAmount;


    public void Add(CurrencyType currencyType, int amount)
    {
        if (amount < 0)
        {
            Debug.LogError("Amount is less than 0");
            return;
        }

        if (_currenciesAmount.ContainsKey(currencyType))
            _currenciesAmount[currencyType].Add(amount);
        else
            _currenciesAmount.Add(currencyType, new Currency(amount));
    }

    public void Spend(CurrencyType currencyType, int amount)
    {
        if (amount < 0)
        {
            Debug.LogError("Amount is less than 0");
            return;
        }

        if (_currenciesAmount.ContainsKey(currencyType))
            _currenciesAmount[currencyType].Spend(amount);
    }
}
