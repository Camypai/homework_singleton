using System;

namespace Homework_Singleton
{
    public class SingletonLazy
    {
        private SingletonLazy(){}
        
        private static readonly Lazy<SingletonLazy> _singleton = new Lazy<SingletonLazy>(() => new SingletonLazy()) ;
        
        private static readonly object Lock = new object();
        
        public string Value { get; private set; }

        public static SingletonLazy GetSingleton(string value)
        {
            lock (Lock)
            {
                if (_singleton.IsValueCreated) return _singleton.Value;
            }
            
            lock (Lock)
            {
                if (!_singleton.IsValueCreated)
                {
                    _singleton.Value.Value = value;
                }
            }

            return _singleton.Value;
        }
    }
}