using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slib.Design
{
    public class Singleton<T> where T : new()
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
}
