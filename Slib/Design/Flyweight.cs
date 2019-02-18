using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slib.Design
{
    public class FlyweightModel
    {
        public interface Flyweight
        {
            void operation();
        }

        public class ConcreteFlyweight : Flyweight
        {
            private string name;
            public int Index { get; set; }
            public ConcreteFlyweight(string name)
            {
                this.name = name;
            }

            public void operation()
            {
                Console.WriteLine("执行元的方法" + name + Index);
            }
        }

        public class FlyweightFactory {
            private Dictionary<string, ConcreteFlyweight> dict = new Dictionary<string, ConcreteFlyweight>();
            public ConcreteFlyweight factory(string name)
            {
                ConcreteFlyweight fly = null;
                dict.TryGetValue(name, out fly);
                if (fly == null)
                {
                    fly = new ConcreteFlyweight(name);
                    dict.Add(name, fly);
                }
                return fly;
            }
        }
        public static void invoke()
        {
            FlyweightFactory factory = new FlyweightFactory();
            ConcreteFlyweight fly = factory.factory("vv");
            fly.Index = 1;
            fly.operation();

            ConcreteFlyweight fly2 = factory.factory("xx");
            fly2.Index = 2;
            fly2.operation();


            ConcreteFlyweight fly3 = factory.factory("vv");
            fly3.Index = 3;
            fly3.operation();
            fly.operation();
            Console.WriteLine(object.ReferenceEquals(fly, fly3));
        }
    }
}
