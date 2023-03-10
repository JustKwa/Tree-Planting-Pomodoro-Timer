using UnityEngine;

public class TimerController : MonoBehaviour
{
    private Timer _timer;
    private StartButton _button;
    private TimeText _timerText;
    private int _pomodoro = 25;
    private int _shortBreak = 5;
    private int _longBreak = 15;

    private void Awake()
    {
        _timer = GetComponentInChildren<Timer>();
        _timer.OnCountDownFinish(OnTimerFinished);

        _button = GetComponentInChildren<StartButton>();
        _button.Initialize(this, _timer);

        _timerText = GetComponentInChildren<TimeText>();
        _timerText.Initialize(_timer);

        SetPomodoro();
    }

    public void StartCountDown() => _timer.StartTimer();

    public void SetPomodoro()
    {
        _timer.SetTime(_pomodoro);
        ResetTimer();
    }

    public void SetShortBreak()
    {
        _timer.SetTime(_shortBreak);
        ResetTimer();
    }

    public void SetLongBreak()
    {
        _timer.SetTime(_longBreak);
        ResetTimer();
    }

    private void ResetTimer()
    {
        _timer.CancelTimer();
        _button.SetState(StartButton.ButtonState.Start);
    }

    public void CancelPomodoro()
    {
        _timer.CancelTimer();
        // Code when player cancels the pomodoro within 10s
    }

    public void StopPomodoro()
    {
        _timer.CancelTimer();
        // Code when player stop the pomodoro
    }

    private void OnTimerFinished()
    {
        _timer.CancelTimer();
        // Code When the timer is finished
    }
}
