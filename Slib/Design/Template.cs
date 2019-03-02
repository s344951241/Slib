using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slib.Design
{
    public class TemplateModel
    {
        public abstract class Template
        {
            protected abstract void method1();
            protected abstract void method2();
            public void Operation()
            {
                method1();
                method2();
            }
        }

        public class ConcreteA : Template
        {
            protected override void method1()
            {
                Console.WriteLine("实现类A的method1");
            }

            protected override void method2()
            {
                Console.WriteLine("实现类A的method2");
            }
        }

        public class ConcreteB : Template
        {
            protected override void method1()
            {
                Console.WriteLine("实现类B的method1");
            }

            protected override void method2()
            {
                Console.WriteLine("实现类B的method2");
            }
        }

        public static void Invoke()
        {
            Template A = new ConcreteA();
            A.Operation();
            A = new ConcreteB();
            A.Operation();
        }
    }
}
