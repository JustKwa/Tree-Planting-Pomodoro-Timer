using UnityEngine;
using TMPro;

public class StartButton : MonoBehaviour
{
    public enum ButtonState { Start, Stop, Cancel }
    private TimerController _timerController;
    private ButtonState _state;
    private Timer _cancelTimer;
    private Timer _mainTimer;
    private TextMeshProUGUI _textMeshPro;
    private int _cancelableDuration = 10;

    private void Awake()
    {
        _state = ButtonState.Start;
        _textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        _cancelTimer = GetComponentInChildren<Timer>();
        _cancelTimer.SetTime(0, _cancelableDuration);
        _cancelTimer.OnCountDownFinish(OnCancelTimerFinished);
    }

    public void Initialize(TimerController timerController, Timer mainTimer)
    {
        _timerController = timerController;
        _mainTimer = mainTimer;
        _mainTimer.OnCountDownFinish(OnMainTimerFinished);
    }

    public void SetState(ButtonState state) => _state = state;

    private void Update()
    {
        switch (_state)
        {
            case ButtonState.Start:
                _textMeshPro.text = "Start";
                break;
            case ButtonState.Stop:
                _textMeshPro.text = "Stop";
                break;
            case ButtonState.Cancel:
                _textMeshPro.text = "Cancel " + "(" + _cancelTimer.Second + ")";
                break;
        }
    }

    public void OnButtonClick()
    {
        switch (_state)
        {
            case ButtonState.Start:
                _cancelTimer.CancelTimer();
                _cancelTimer.StartTimer();
                _timerController.StartCountDown();
                _state = ButtonState.Cancel;
                break;
            case ButtonState.Stop:
                _timerController.StopPomodoro();
                _state = ButtonState.Start;
                break;
            case ButtonState.Cancel:
                _timerController.CancelPomodoro();
                _state = ButtonState.Start;
                break;
        }
    }

    private void OnCancelTimerFinished() => _state = ButtonState.Stop;

    private void OnMainTimerFinished() => _state = ButtonState.Start;
}
