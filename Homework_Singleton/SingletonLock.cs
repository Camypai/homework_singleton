namespace Homework_Singleton
{
    public class SingletonLock
    {
        private SingletonLock(){}

        private static SingletonLock _singleton;
        
        public string Value { get; private set; }
        
        private static readonly object Lock = new object();

        public static SingletonLock GetSingleton(string value)
        {
            if (_singleton != null) return _singleton;
            
            lock (Lock)
            {
                _singleton ??= new SingletonLock
                {
                    Value = value
                };
            }

            return _singleton;
        }
    }
}