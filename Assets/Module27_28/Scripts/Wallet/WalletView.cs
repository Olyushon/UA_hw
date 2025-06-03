using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    private Wallet _wallet;
    [SerializeField] private CurrencyView _currencyViewPrefab;
    [SerializeField] private Sprite _coinIcon;
    [SerializeField] private Sprite _gemIcon;
    [SerializeField] private Sprite _energyIcon;

    public void Initialize(Wallet wallet)
    {
        _wallet = wallet;
        Show();
    }

    public void Show()
    {
        Dictionary<CurrencyType, int> currenciesAmount = _wallet.CurrenciesAmount;

        foreach (KeyValuePair<CurrencyType, int> currency in currenciesAmount)
        {
            switch (currency.Key)
            {
                case CurrencyType.Coin:
                    CreateCurrencyView(currency.Key, _coinIcon, currency.Value);
                    break;
                case CurrencyType.Gem:
                    CreateCurrencyView(currency.Key, _gemIcon, currency.Value);
                    break;
                case CurrencyType.Energy:
                    CreateCurrencyView(currency.Key, _energyIcon, currency.Value);
                    break;
                default:
                    Debug.LogError($"Currency type {currency.Key} not found");
                    break;
            }
        }
    }

    private void CreateCurrencyView(CurrencyType currencyType, Sprite icon, int amount)
    {
        CurrencyView currencyView = Instantiate(_currencyViewPrefab, transform);
        currencyView.Initialize(currencyType, icon, amount, _wallet);
    }

}
