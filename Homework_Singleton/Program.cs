using System;
using System.Threading;

namespace Homework_Singleton
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var processLock1 = new Thread(() =>
            {
                TestSingletonLock("Thread lock 1");
            });
            
            var processLock2 = new Thread(() =>
            {
                TestSingletonLock("Thread lock 2");
            });
            
            var processLazy1 = new Thread(() =>
            {
                TestSingletonLazy("Thread lazy 1");
            });
            
            var processLazy2 = new Thread(() =>
            {
                TestSingletonLazy("Thread lazy 2");
            });
            
            processLock1.Start();
            processLock2.Start();
            
            processLock1.Join();
            processLock2.Join();
            
            processLazy1.Start();
            processLazy2.Start();
            
            processLazy1.Join();
            processLazy2.Join();
        }

        private static void TestSingletonLock(string value)
        {
            var singleton = SingletonLock.GetSingleton(value);
            Console.WriteLine(singleton.Value);
        }
        
        private static void TestSingletonLazy(string value)
        {
            var singleton = SingletonLazy.GetSingleton(value);
            Console.WriteLine(singleton.Value);
        }
    }
}