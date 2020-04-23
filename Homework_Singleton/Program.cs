using System;
using System.Threading;

namespace Homework_Singleton
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var process1 = new Thread(() =>
            {
                TestSingleton("Thread 1");
            });
            
            var process2 = new Thread(() =>
            {
                TestSingleton("Thread 2");
            });
            
            process1.Start();
            process2.Start();
            
            process1.Join();
            process2.Join();
        }

        private static void TestSingleton(string value)
        {
            var singleton = SingletonLock.GetSingleton(value);
            Console.WriteLine(singleton.Value);
        }
    }
}