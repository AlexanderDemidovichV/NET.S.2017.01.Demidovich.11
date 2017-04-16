using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Task1.ConsoleTest
{
    public sealed class Subscriber
    {
        public void Register(Timer timer)
        {
            timer.TimeOut += SubscriberMsg;
        }

        public void Unregister(Timer timer)
        {
            timer.TimeOut -= SubscriberMsg;
        }

        private void SubscriberMsg(object sender, TimeOutEventArgs eventArgs)
        {
            Console.WriteLine("Event was raised: {0}.", eventArgs.Timeout);
        }
    }
}
