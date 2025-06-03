using UnityEngine;

public class ItemsTimerView : MonoBehaviour, ITimerView
{
    [SerializeField] private GameObject _itemIconPrefab;
    private TimerService _timerService;

    public void Initialize(TimerService timerService)
    {
        _timerService = timerService;
        _timerService.TimeChanged += UpdateView;

        UpdateView(_timerService.Time);
    }

    public void UpdateView(int timeLeft)
    {   
        DestroyAllChildren();

        for (int i = 0; i < timeLeft; i++)
        {
            Instantiate(_itemIconPrefab, transform);
        }
    }

    private void DestroyAllChildren()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void OnDestroy()
    {
        _timerService.TimeChanged -= UpdateView;
    }
}
