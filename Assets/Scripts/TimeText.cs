using UnityEngine;

public class TimeText : MonoBehaviour
{
    private TMPro.TextMeshProUGUI _textMeshPro;
    private Timer _timer;

    public void Initialize(Timer timer)
    {
        _timer = timer;
    }

    private void Awake() => _textMeshPro = GetComponent<TMPro.TextMeshProUGUI>();

    private void Start() => _textMeshPro.text = "25:00";

    private void LateUpdate() => DisplayTime();

    private void DisplayTime() => _textMeshPro.text = string.Format("{0:D2}:{1:D2}", _timer.Minute.ToString("00"), _timer.Second.ToString("00"));
}
