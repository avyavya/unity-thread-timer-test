using UnityEngine;
using System;


public class ThreadingScheduleComponent : MonoBehaviour
{
    private readonly ThreadingTimer.Timer timer = new ThreadingTimer.Timer();

    public event Action<ThreadingScheduleComponent> OnTimeout;

    public bool IsRepeating { get; set; }


    public void SetTimeout(uint timeout)
    {
        IsRepeating = false;
        timer.SetTimeout(timeout);
    }

    public void SetInterval(uint interval)
    {
        IsRepeating = true;
        timer.SetTimeout(interval);
    }

    public void SetInterval(uint interval, uint offset)
    {
        IsRepeating = true;
        timer.SetTimeout(interval, offset);
    }

    private void Update()
    {
        if (!timer.IsTimeout) return;

        timer.IsTimeout = false;

        if (OnTimeout == null) return;

        var cb = OnTimeout;

        if (!IsRepeating)
        {
            OnTimeout = null;
            Stop();
        }

        cb(this);
    }

    public void Stop()
    {
        timer.Stop();
    }
}
