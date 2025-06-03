using UnityEngine;
using UnityEngine.UI;

public class SliderTimerView : MonoBehaviour, ITimerView
{
    [SerializeField] private Slider _slider;

    private TimerService _timerService;

    public void Initialize(TimerService timerService)
    {
        _timerService = timerService;
        _timerService.TimeChanged += UpdateView;

        UpdateView(_timerService.Time);
    }

    public void UpdateView(int timeLeft)    
    {
        _slider.value = (float) timeLeft / _timerService.Time;
    }

    private void OnDestroy()
    {
        _timerService.TimeChanged -= UpdateView;
    }
}