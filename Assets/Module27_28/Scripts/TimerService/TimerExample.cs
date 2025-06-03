using UnityEngine;

public class TimerExample : MonoBehaviour
{
    [SerializeField] private int _time = 10;
    [SerializeField] private ItemsTimerView _itemsTimerView;
    [SerializeField] private SliderTimerView _sliderTimerView;

    private TimerService _timerService;

    private void Awake()
    {
        _timerService = new TimerService(_time, this);
        _itemsTimerView.Initialize(_timerService);
        _sliderTimerView.Initialize(_timerService);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            if (_timerService.InProcess == false)
                _timerService.Start();
            else if (_timerService.IsPaused)
                _timerService.Resume();
            else
                _timerService.Pause();

        if (Input.GetKeyDown(KeyCode.R))
            _timerService.Reset();
    }
}
