using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slib.Design
{
    public class CompositeModel
    {
        public abstract class Component {
            public abstract void add(Component c);
            public abstract void remove(Component c);
            public abstract Component getChild(int i);
            public abstract void operation();
        }

        public class Leaf : Component
        {
            public override void add(Component c)
            {
                throw new NotImplementedException();
            }

            public override Component getChild(int i)
            {
                throw new NotImplementedException();
            }

            public override void operation()
            {
                Console.WriteLine("执行叶子节点方法");
            }

            public override void remove(Component c)
            {
                throw new NotImplementedException();
            }
        }

        public class Composite : Component
        {
            private List<Component> list = new List<Component>();
            public override void add(Component c)
            {
                list.Add(c);
            }

            public override Component getChild(int i)
            {
                return list[i];
            }

            public override void operation()
            {
                foreach (Component c in list)
                {
                    c.operation();
                }
            }

            public override void remove(Component c)
            {
                list.Remove(c);
            }
        }

        public static void invoke()
        {
            Composite com = new Composite();
            com.add(new Leaf());
            Composite comChild = new Composite();
            comChild.add(new Leaf());
            comChild.add(new Leaf());
            com.add(comChild);
            com.operation();
        }
    }
}
