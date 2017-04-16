using System;
using System.Threading;
using System.Timers;

namespace Task1
{
    public class Timer
    {
        public event EventHandler<TimeOutEventArgs> TimeOut = delegate { };

        public void SetTimer(int elapse)
        {
            if (elapse < 0)
                throw new ArgumentOutOfRangeException($"{nameof(elapse)} is less than zero.");
            Thread.Sleep(elapse);
            OnTimeOut(this, new TimeOutEventArgs(elapse));
        }

        protected virtual void OnTimeOut(object sender, TimeOutEventArgs e) => TimeOut(sender, e);
    }
}
