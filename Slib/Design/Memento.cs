using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slib.Design
{
    public class MementoModel
    {
        public class Memento
        {
            public string State { get; set; }
            public Memento(string state)
            {
                State = state;
            }
            public string getState()
            {
                return State;
            }
        }

        public class CareTaker {
            private List<Memento> mementoList = new List<Memento>();

            public void add(Memento state)
            {
                mementoList.Add(state);
            }

            public Memento get(int index)
            {
                return mementoList[index];
            }
        }
        public class Originator
        {
            private string state;
            public Memento createMomento()
            {
                Console.WriteLine("设置备忘录");
                return new Memento(this.state);
            }
            public void restoreMemento(Memento mo)
            {
                Console.WriteLine("恢复备忘录");
                state = mo.State;
            }
            public void setState(string state)
            {
                this.state = state;
            }
            public string getState()
            {
                return state;
            }
            public string getStateFormMemento(Memento mo)
            {
                return mo.getState();
            }
        }

        public static void invoke()
        {
            Originator originator = new Originator();
            CareTaker careTaker = new CareTaker();
            originator.setState("State #1");
            originator.setState("State #2");
            careTaker.add(originator.createMomento());
            originator.setState("State #3");
            careTaker.add(originator.createMomento());
            originator.setState("State #4");

            Console.WriteLine("Current State: " + originator.getState());
            originator.getStateFormMemento(careTaker.get(0));
            Console.WriteLine("First saved State: " + originator.getState());
            originator.getStateFormMemento(careTaker.get(1));
            Console.WriteLine("Second saved State: " + originator.getState());
        }
    }
}
