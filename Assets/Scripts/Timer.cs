using UnityEngine;

public class Timer : MonoBehaviour
{
    private bool _isActive = false;
    private float _seconds = 10.0f;
    private int _maxMinutes;
    private int _minutes;

    /// <summary> returns the second. </summary>
    public float Second
    {
        get
        {
            return (int)_seconds;
        }
    }

    /// <summary> returns the minute. </summary>
    public int Minute
    {
        get
        {
            return _minutes;
        }
    }

    public bool IsActive() => _isActive;

    private void Update()
    {
        if (!_isActive) { return; }
        CountDown(Time.deltaTime);
    }

    /// <summary> Set the minute for the timer to countdown. </summary>
    public void SetTime(int maxMinutes)
    {
        _maxMinutes = maxMinutes;
        _minutes = maxMinutes;
    }

    /// <summary> Set the timer to active. </summary>
    public void StartTimer() { _isActive = true; }

    /// <summary> Disable the timer </summary>
    public void StopTimer() { _isActive = false; }

    /// <summary> Disable the timer while resetting the countdown. </summary>
    public void CancelTimer()
    {
        _isActive = false;
        _minutes = _maxMinutes;
    }

    /// <summary> Start counting down while returning true if it is active, false if it finishes counting down.</summary>
    public bool CountDown(float deltaTime)
    {
        _seconds -= deltaTime;

        if (_seconds >= 0.0f) { return true; }

        _seconds = 10.0f;
        _minutes--;

        if (_minutes > 0) { return true; }

        // StopTimer();
        return false;
    }

}
