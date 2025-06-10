using UnityEngine;
using UnityEngine.UI;

public class SliderTimerView : MonoBehaviour, ITimerView
{
    [SerializeField] private Slider _slider;

    private TimerService _timerService;
    private int _timerTotalTime;

    public void Initialize(TimerService timerService)
    {
        _timerService = timerService;
        _timerTotalTime = _timerService.Time;
        
        _timerService.TimeLeft.Changed += OnTimeChanged;

        UpdateView(_timerService.TimeLeft.Value);
    }

    private void OnTimeChanged(int oldTimeLeft, int newTimeLeft)
    {
        UpdateView(newTimeLeft);
    }

    public void UpdateView(int timeLeft)    
    {
        _slider.value = (float) timeLeft / _timerTotalTime;
    }

    private void OnDestroy()
    {
        _timerService.TimeLeft.Changed -= OnTimeChanged;
    }
}