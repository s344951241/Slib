using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slib.Design
{
    public class VisitorModel
    {
        public interface Visitor
        {
            void visit(PartA a);
            void visit(PartB b);
        }

        public interface Part
        {
            void Operation(Visitor visitor);
        }

        public class PartA : Part
        {
            public void Operation(Visitor visitor)
            {
                visitor.visit(this);
            }
        }

        public class PartB : Part
        {
            public void Operation(Visitor visitor)
            {
                visitor.visit(this);
            }
        }

        public class ConcreteVisitorA : Visitor
        {
            public void visit(PartA a)
            {
                Console.WriteLine("ConcreteVisitorA visit PartA");
            }

            public void visit(PartB b)
            {
                Console.WriteLine("ConcreteVisitorA visit PartB");
            }
        }

        public static void Invoke()
        {
            Visitor v = new ConcreteVisitorA();
            Part a = new PartA();
            Part b = new PartB();
            a.Operation(v);
        }
    }
}
