using System;

namespace Task1.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer = new Timer();
            var sub1 = new Subscriber();
            var sub2 = new Subscriber();
            sub1.Register(timer);
            sub2.Register(timer);
            timer.TimeOut += (sender, eventArgs) =>
            {
                Console.WriteLine("Custom sub.");
            };
            timer.SetTimer(3000, "WAKE UP");
        }
    }
}
