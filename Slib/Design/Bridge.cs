using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slib.Design
{
    public class Bridge
    {
        public interface Implementor {
            void operation();
        }

        public class ConcreteImplementorA : Implementor
        {
            public void operation()
            {
                Console.WriteLine("ConcreteImplementorA 实现Implementor的operation方法");
            }
        }
        public class ConcreteImplementorB : Implementor
        {
            public void operation()
            {
                Console.WriteLine("ConcreteImplementorB 实现Implementor的operation方法");
            }
        }

        public abstract class Abstraction
        {
            private Implementor Imp;
            public void SetImp(Implementor imp)
            {
                Imp = imp;
            }
            public Implementor GetImp()
            {
                return Imp;
            }
            public abstract void opertion();
        }

        public class BridgeClass : Abstraction
        {
            public override void opertion()
            {
                GetImp().operation();
            }
        }

        public static void invoke()
        {
            BridgeClass bridge = new BridgeClass();
            bridge.SetImp(new ConcreteImplementorA());
            bridge.opertion();
            bridge.SetImp(new ConcreteImplementorB());
            bridge.opertion();
        }
    }
}
