using UnityEngine;


namespace ThreadingTimer
{

    public class Timer
    {

        private System.Threading.Timer timer;

        public bool IsTimeout { get; set; }


        public Timer()
        {
            timer = new System.Threading.Timer(OnTimeout);
        }

        ~Timer()
        {
            timer.Dispose();
            Debug.Log("timer destroyed.");
        }


        public void SetTimeout(uint timeout)
        {
            SetTimeout(timeout, timeout);
        }

        public void SetTimeout(uint timeout, uint delay)
        {
            Debug.Log("set timeout: " + timeout + ", delay: " + delay);
            IsTimeout = false;
            timer.Change(delay, timeout);
        }

        private void OnTimeout(object o)
        {
            IsTimeout = true;
        }

        public void Stop()
        {
            IsTimeout = false;
            timer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
        }

    }

}
