using UnityEngine;

public class TimerController : MonoBehaviour
{
    private Timer _timer;
    private Button _button;
    private TMPro.TextMeshProUGUI _timerText;
    private int _pomodoro = 25;
    private int _shortBreak = 5;
    private int _longBreak = 15;

    private void Awake()
    {
        _timer = GetComponentInChildren<Timer>();
        _button = GetComponentInChildren<Button>();
        _timerText = GetComponentInChildren<TMPro.TextMeshProUGUI>();
        _button.Initialize(this);
    }

    public void StartPomodoro()
    {
        _timer.SetTime(_pomodoro);
        _timer.StartTimer();
    }

    public void StartShortBreak()
    {
        _timer.CancelTimer();
        _timer.SetTime(_shortBreak);
        _timer.StartTimer();
    }

    public void StartLongBreak()
    {
        _timer.CancelTimer();
        _timer.SetTime(_longBreak);
        _timer.StartTimer();
    }

    public void CancelPomodoro()
    {
        _timer.CancelTimer();
    }

    public void StopPomodoro()
    {
        _timer.CancelTimer();
    }
}
