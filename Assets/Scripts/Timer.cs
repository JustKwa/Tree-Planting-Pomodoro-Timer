using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private bool _isActive = false;
    private float _maxSeconds;
    private float _seconds;
    private int _maxMinutes;
    private int _minutes;
    private Action _action;

    /// <summary> returns the second. </summary>
    public int Second => (int)_seconds;

    /// <summary> returns the minute. </summary>
    public int Minute => _minutes;

    public bool IsActive() => _isActive;

    private void Update()
    {
        if (!_isActive) { return; }
        CountDown(Time.deltaTime);
    }

    /// <summary> Set the minute for the timer to countdown. </summary>
    public void SetTime(int maxMinutes, float? seconds = 0.0f)
    {
        _maxMinutes = maxMinutes;
        _minutes = maxMinutes;
        _maxSeconds = (float)seconds;
        _seconds = (float)seconds;
    }

    /// <summary> Set the timer to active. </summary>
    public void StartTimer() => _isActive = true;

    /// <summary> Disable the timer </summary>
    public void StopTimer() => _isActive = false;

    /// <summary> Disable the timer while resetting the countdown. </summary>
    public void CancelTimer()
    {
        StopTimer();
        _minutes = _maxMinutes;
        _seconds = _maxSeconds;
    }

    /// <summary> Start counting down while returning true if it is active, false if it finishes counting down.</summary>
    public void CountDown(float deltaTime)
    {
        _seconds -= deltaTime;

        if (_seconds > 0.0f) { return; }

        _seconds = 59.0f;
        _minutes--;

        if (_minutes > 0) { return; }
        CancelTimer();
        _action?.Invoke();
    }

    public void OnCountDownFinish(Action callBack) { _action = callBack; }
}
