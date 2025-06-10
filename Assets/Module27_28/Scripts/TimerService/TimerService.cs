using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimerService
{
    private MonoBehaviour _coroutineRunner;
    private int _time;
    private ReactableVariable<int> _timeLeft;
    private Coroutine _timerCoroutine;
    private bool _isPaused;

    public int Time => _time;
    public IReactableVariable<int> TimeLeft => _timeLeft;
    public bool InProcess => _timerCoroutine != null;
    public bool IsPaused => _isPaused;
    
    public TimerService(int time, MonoBehaviour coroutineRunner)  
    {
        _time = time;
        _timeLeft = new ReactableVariable<int>(time);
        _coroutineRunner = coroutineRunner;
    }

    public void Start()  
    {
        if (_timerCoroutine == null)
            _timerCoroutine = _coroutineRunner.StartCoroutine(TimerCoroutine());
    }

    public void Pause()
    {
        if (_timerCoroutine == null)
            return;

        _isPaused = true;
    }   

    public void Resume()
    {
        if (_timerCoroutine == null)
            return;

        _isPaused = false;
    }

    public void Reset()
    {
        _coroutineRunner.StopCoroutine(_timerCoroutine);
        _timerCoroutine = null;
        _isPaused = false;

        _timeLeft.Value = _time;
    }   
    
    private IEnumerator TimerCoroutine()
    {
        while (_timeLeft.Value > 0)
        {
            yield return new WaitWhile(() => _isPaused);

            yield return new WaitForSeconds(1);
            _timeLeft.Value--;
        }
    }
}
