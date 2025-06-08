using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CurrencyView : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _amountText;
    private Currency _currency;

    public void Initialize(Sprite icon, Currency currency)
    {
        SetIcon(icon);
        SetText(currency.Amount);

        _currency = currency;
        _currency.AmountChanged += OnCurrencyAmountChanged;
    }

    private void OnDisable()
    {
        _currency.AmountChanged -= OnCurrencyAmountChanged;
    }

    private void OnCurrencyAmountChanged(int amount)
    {
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
