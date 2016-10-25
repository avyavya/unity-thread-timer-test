

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
        }


        public void SetTimeout(uint timeout)
        {
            SetTimeout(timeout, timeout);
        }

        public void SetTimeout(uint timeout, uint delay)
        {
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
