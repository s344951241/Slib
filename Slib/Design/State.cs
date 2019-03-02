using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slib.Design
{
    public class StateModel
    {
        public interface State
        {
            void operation(Context context);
        }
        public class Context
        {
            public State State { get; set; }
            public Context()
            {
                State = null;
            }
        }
        public class StateA : State
        {
            public void operation(Context context)
            {
                Console.WriteLine("执行StateA时的方法");
                context.State = this;
            }
            public override string ToString()
            {
                return "StateA";
            }
        }

        public class StateB : State
        {
            public void operation(Context context)
            {
                Console.WriteLine("执行StateB时的方法");
                context.State = this;
            }

            public override string ToString()
            {
                return "StateB";
            }
        }
        public static void invoke()
        {
            Context con = new Context();
            StateA a = new StateA();
            a.operation(con);
            Console.WriteLine("现在的状态" + con.State);
            StateB b = new StateB();
            b.operation(con);
            Console.WriteLine("现在的状态" + con.State);
        }
    }
}
