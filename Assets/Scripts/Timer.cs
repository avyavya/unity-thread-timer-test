using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{

    [SerializeField] private Button button;
    [SerializeField] private Text label;
    [SerializeField] private Text timeLabel;
    private uint elapsed;

    private void Start()
    {
        InitializeTime();
    }

    public void OnClick()
    {
        label.text = "Started.";

        var co = label.gameObject.AddComponent<ThreadingScheduleComponent>();
        co.OnTimeout += OnTimeout;
        co.SetTimeout(2000);
    }

    private void OnTimeout(ThreadingScheduleComponent o)
    {
        label.text = "Timed out!";

        o.OnTimeout += (o2) =>
        {
            label.text = "";
            Destroy(o2);
        };
        o.SetTimeout(1000);
    }

    private void InitializeTime()
    {
        var co = timeLabel.gameObject.GetComponent<ThreadingScheduleComponent>();
        var interval = 100u;

        co.OnTimeout += (o) =>
        {
            elapsed += interval;
            var time = elapsed / 1000f;
            timeLabel.text = time.ToString("F1");
        };

        co.SetInterval(interval, 0);
    }

}
