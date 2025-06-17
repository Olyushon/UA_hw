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
        IReadOnlyDictionary<CurrencyType, Currency> currenciesAmount = _wallet.CurrenciesAmount;

        foreach (KeyValuePair<CurrencyType, Currency> currencyPair in currenciesAmount)
        {
            switch (currencyPair.Key)
            {
                case CurrencyType.Coin:
                    CreateCurrencyView(_coinIcon, currencyPair.Value);
                    break;
                case CurrencyType.Gem:
                    CreateCurrencyView(_gemIcon, currencyPair.Value);
                    break;
                case CurrencyType.Energy:
                    CreateCurrencyView(_energyIcon, currencyPair.Value);
                    break;
                default:
                    Debug.LogError($"Currency type {currencyPair.Key} not found");
                    break;
            }
        }
    }

    private void CreateCurrencyView(Sprite icon, Currency currency)
    {
        CurrencyView currencyView = Instantiate(_currencyViewPrefab, transform);
        currencyView.Initialize(icon, currency);
    }

}
