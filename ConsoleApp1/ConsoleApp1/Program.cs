using System;

namespace ConsoleApp1
{
    class Program
    {
        public class WorkerEventArgs : EventArgs
        {
            public char value { get; }
            public WorkerEventArgs(char Value)
            {
                value = Value;
            }
        }
        public class Worker
        {
            public event EventHandler<char> OnKeyPresed;

            public void Run()
            {
                while (true)
                {
                    Console.WriteLine("Введите символ: ");
                    var symbol = Console.ReadKey();
                    if (symbol.Key == ConsoleKey.C)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine();
                        OnKeyPresed?.Invoke(this, symbol.KeyChar);
                    }

                }
            }
        }
        public class Subscriber
        {
            public void Method()
            {
                var worker = new Worker();
                worker.OnKeyPresed += Print;
                worker.Run();
            }
            public void Print(object sender, char e)
            {
                Console.WriteLine(e);
            }
        }
        static void Main(string[] args)
        {
            Subscriber subscriber = new Subscriber();
            subscriber.Method();

        }
    }
}

