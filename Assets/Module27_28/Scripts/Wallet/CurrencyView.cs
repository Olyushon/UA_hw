using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CurrencyView : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _amountText;
    private CurrencyType _type;
    private Wallet _wallet;

    public void Initialize(CurrencyType type, Sprite icon, int amount, Wallet wallet)
    {
        _type = type;
        SetIcon(icon);
        SetText(amount);

        _wallet = wallet;
        _wallet.CurrencyAmountChanged += OnCurrencyAmountChanged;
    }

    private void OnDisable()
    {
        _wallet.CurrencyAmountChanged -= OnCurrencyAmountChanged;
    }

    private void OnCurrencyAmountChanged(CurrencyType currencyType, int amount)
    {
        if (currencyType == _type)
            SetText(amount);
    }

    private void SetIcon(Sprite sprite)
    {
        _icon.sprite = sprite;
    }

    private void SetText(int amount)
    {
        _amountText.text = amount.ToString();
    }
}
