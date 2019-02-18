using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slib.Design
{
    public class ObserverModel
    {
        public interface Observer
        {
            void operation(Subject sub, params object[] objs);
        }
        public abstract class Subject
        {
            private List<Observer> obList = new List<Observer>();
            public void addObserver(Observer o)
            {
                obList.Add(o);
            }
            public void delObserver(Observer o)
            {
                obList.Remove(o);
            }

            public void notifyObserver()
            {
                for (int i = 0; i < obList.Count; i++)
                {
                    obList[i].operation(this, null);
                }
            }
        }
        public class ConcreteSubject : Subject
        {
            public void operation()
            {
                base.notifyObserver();
            }
        }
        public class ConcreteObserver : Observer
        {
            public void operation(Subject sub, params object[] objs)
            {
                Console.WriteLine("观察者接受到" + sub + "变化发生" + objs);
            }
        }
        public static void invoke()
        {
            ConcreteSubject subject = new ConcreteSubject();
            Observer ob = new ConcreteObserver();
            subject.addObserver(ob);
            subject.notifyObserver();
        }
    }
}
