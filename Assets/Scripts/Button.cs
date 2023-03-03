using UnityEngine;
using TMPro;

public class Button : MonoBehaviour
{
    public enum ButtonState { Start, Stop, Cancel }

    private TimerController _timerController;
    private ButtonState _state;
    private Timer _timer;
    private TextMeshProUGUI _textMeshPro;
    private int _cancelableDuration = 10;

    public void Initialize(TimerController timerController) => _timerController = timerController;

    public void SetState(ButtonState state) => _state = state;

    private void Awake()
    {
        _state = ButtonState.Start;
        _textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        _timer = GetComponentInChildren<Timer>();
        _timer.SetTime(0, _cancelableDuration);
        _timer.OnCountDownFinish(OnTimerFinished);
    }

    private void Update()
    {
        // Set text for the button
        switch (_state)
        {
            case ButtonState.Start:
                _textMeshPro.text = "Start";
                break;
            case ButtonState.Stop:
                _textMeshPro.text = "Stop";
                break;
            case ButtonState.Cancel:
                _textMeshPro.text = "Cancel " + "(" + _timer.Second + ")";
                break;
        }
    }

    public void OnButtonClick()
    {
        switch (_state)
        {
            case ButtonState.Start:
                _timer.StartTimer();
                _timerController.StartPomodoro();
                _state = ButtonState.Cancel;
                break;
            case ButtonState.Stop:
                _timer.CancelTimer();
                _timerController.StopPomodoro();
                _state = ButtonState.Start;
                break;
            case ButtonState.Cancel:
                _timer.CancelTimer();
                _timerController.CancelPomodoro();
                _state = ButtonState.Start;
                break;
        }
    }

    private void OnTimerFinished() => _state = ButtonState.Stop;

}
