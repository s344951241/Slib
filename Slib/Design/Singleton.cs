#define NEW
using System;

namespace Slib.Design
{
    public sealed class Singleton<T> where T : new()
    {
        private static readonly object _lock = new object();
        private static T _instance;

        protected Singleton()
        {
            
        }
        public static bool Exists
        {
            
            get {
                return _instance !=null;
            }
        }
        private static T Instance
        {
            //double check
            get {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new T();
                        }
                    }
                }
                return _instance;
            }
        }

        public static T GetInstance()
        {
            return Instance;
        }
    }

    public sealed class SingleTon
    {
#if OLD
        private static readonly SingleTon instance = new SingleTon();

        static SingleTon()
        {

        }

        private SingleTon()
        {

        }

        public static SingleTon Instance {
            get {
                return instance;
            }
        }
#elif NEW
        private static readonly Lazy<SingleTon> lazy = new Lazy<SingleTon>(() => new SingleTon());
        public static SingleTon Instance { get { return lazy.Value; } }
        private SingleTon()
        {

        }
#endif
    }
}
