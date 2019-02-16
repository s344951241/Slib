using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slib.Design
{
    public class Adapter
    {
        public interface InterfaceA
        {
            void InterfaceAFun();
        }
        public class ClassA : InterfaceA
        {
            public void InterfaceAFun()
            {
                Console.WriteLine("this is classA's function InterfaceFun from InterfaceA");
            }

        }

        public interface InterfaceB
        {
            void InterfaceBFun();
        }

        public class ClassAdapter : ClassA, InterfaceB
        {
            public void InterfaceBFun()
            {
                Console.WriteLine("classAdapter: ");
                this.InterfaceAFun();
            }
        }

        public class TargerAdapter : InterfaceB
        {
            private ClassA a = new ClassA();
            public void InterfaceBFun()
            {
                Console.WriteLine("targetAdapter:");
                a.InterfaceAFun();
            }
        }
        public static void invoke()
        {
            ClassAdapter adapter = new ClassAdapter();
            adapter.InterfaceBFun();

            TargerAdapter adapter1 = new TargerAdapter();
            adapter1.InterfaceBFun();
        }
    }
}
