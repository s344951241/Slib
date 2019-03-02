using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slib.Design
{
    public class NullPattern
    {
        public abstract class AbstractCustomer
        {
            protected string name;
            public abstract bool IsNull();
            public abstract string GetName();
        }

        public class RealCustomer : AbstractCustomer
        {
            public RealCustomer(string name)
            {
                this.name = name;
            }
            public override string GetName()
            {
                return name;
            }

            public override bool IsNull()
            {
                return false;
            }
        }

        public class NullCustomer : AbstractCustomer
        {
            public override string GetName()
            {
                return "Not Available in Customer Database";
            }

            public override bool IsNull()
            {
                return true;
            }
        }

        public class CustomerFactory {
            public static readonly string[] names = { "Rob", "Joe", "Julie" };

            public static AbstractCustomer GetCustomer(string name)
            {
                for (int i = 0; i < names.Length; i++)
                {
                    if (names[i].Equals(name, StringComparison.OrdinalIgnoreCase))
                    {
                        return new RealCustomer(name);
                    }
                }
                return new NullCustomer();
            }
        }

        public static void Invoke()
        {
            AbstractCustomer customer1 = CustomerFactory.GetCustomer("Rob");
            AbstractCustomer customer2 = CustomerFactory.GetCustomer("Bob");
            AbstractCustomer customer3 = CustomerFactory.GetCustomer("Julie");
            AbstractCustomer customer4 = CustomerFactory.GetCustomer("Laura");

            Console.WriteLine("Customers");
            Console.WriteLine(customer1.GetName());
            Console.WriteLine(customer2.GetName());
            Console.WriteLine(customer3.GetName());
            Console.WriteLine(customer4.GetName());
        }
    }
}
