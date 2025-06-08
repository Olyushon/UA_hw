using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalletExample : MonoBehaviour
{
    [SerializeField] private WalletView _walletView;
    
    private Wallet _wallet;

    private void Awake()
    {
        _wallet = new Wallet(new Dictionary<CurrencyType, Currency>
        {
            { CurrencyType.Coin, new Currency(100) },
            { CurrencyType.Gem, new Currency(50) },
            { CurrencyType.Energy, new Currency(10) }
        });

        _walletView.Initialize(_wallet);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            _wallet.Add(CurrencyType.Coin, 20);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            _wallet.Spend(CurrencyType.Coin, 10);

        if (Input.GetKeyDown(KeyCode.Alpha3))
            _wallet.Add(CurrencyType.Gem, 10);

        if (Input.GetKeyDown(KeyCode.Alpha4))
            _wallet.Spend(CurrencyType.Gem, 5);

        if (Input.GetKeyDown(KeyCode.Alpha5))
            _wallet.Add(CurrencyType.Energy, 2);

        if (Input.GetKeyDown(KeyCode.Alpha6))
            _wallet.Spend(CurrencyType.Energy, 1);
    }
}   
