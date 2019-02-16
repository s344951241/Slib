using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slib.Design
{
    public class FacadeModel
    {
        public class ClassA
        {
            public void doA()
            {
                Console.WriteLine("做事情A");
            }


        }

        public class ClassB
        {
            public void doB()
            {
                Console.WriteLine("做事情B");
            }
        }

        public class Facade
        {
            ClassA A;
            ClassB B;
            public Facade()
            {
                A = new ClassA();
                B = new ClassB();
            }

            public void doA()
            {
                A.doA();
            }

            public void doB()
            {
                B.doB();
            }

        }

        public static void invoke()
        {
            Facade facade = new Facade();
            facade.doA();
            facade.doB();
        }
    }
}
