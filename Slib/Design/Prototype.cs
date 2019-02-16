using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slib.Design
{
    public class PrototypeModel
    {
        public abstract class Prototype
        {
            public string Name { set; get; }
            public Prototype(string name)
            {
                Name = name;

            }
            public abstract Prototype clone();
        }

        public class PrototypeA : Prototype
        {
            public PrototypeA(string name) : base(name)
            {
            }

            public override Prototype clone()
            {
                return this.MemberwiseClone() as Prototype;
            }
        }

        public class PrototypeB : Prototype
        {
            public PrototypeB(string name) : base(name)
            {
            }

            public override Prototype clone()
            {
                return this.MemberwiseClone() as Prototype;
            }
        }

        public static void invoke()
        {
            PrototypeA a = new PrototypeA("xx");
            PrototypeA a1 = a.clone() as PrototypeA;
            Console.WriteLine("clone a " + a1.Name);
            PrototypeB b = new PrototypeB("vv");
            PrototypeB b1 = b.clone() as PrototypeB;
            Console.WriteLine("clone b " + b1.Name);
        }
    }
}
