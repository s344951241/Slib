using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slib.Design
{
    public class StrategyModel
    {
        public interface Strategy
        {
            void Operation();
        }

        public class ConcreteStrategyA : Strategy
        {
            public void Operation()
            {
                Console.WriteLine("执行策略A");
            }
        }

        public class ConcreteStrategeB : Strategy
        {
            public void Operation()
            {
                Console.WriteLine("执行策略B");
            }
        }

        public class Context
        {
            private Strategy m_strategy;
            public Context(Strategy strategy)
            {
                m_strategy = strategy;
            }
            public void Operation()
            {
                m_strategy.Operation();
            }
        }

        public static void Invoke()
        {
            Context context = new Context(new ConcreteStrategyA());
            context.Operation();
        }
    }
}
