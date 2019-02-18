using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slib.Design
{
    public class IteratorModel
    {
        public abstract class Iterator
        {
            public abstract object First();
            public abstract object Next();
            public abstract bool IsDone();
            public abstract object CurrentItem();
        }

        public abstract class Aggregate
        {
            public abstract Iterator CreateIterator();
        }

        public class ConcreteIterator : Iterator
        {
            private ConcreteAggregate aggregate;
            private int current = 0;

            public ConcreteIterator(ConcreteAggregate aggregate)
            {
                this.aggregate = aggregate;
            }

            public override object CurrentItem()
            {
                return aggregate[current];
            }

            public override object First()
            {
                return aggregate[0];
            }

            public override bool IsDone()
            {
                return current >= aggregate.Count;
            }

            public override object Next()
            {
                object ret = null;
                if (current < aggregate.Count - 1)
                {
                    ret = aggregate[++current];
                }
                return ret;
            }
        }
        public class ConcreteAggregate : Aggregate
        {
            private ArrayList item = new ArrayList();

            public override Iterator CreateIterator()
            {
                return new ConcreteIterator(this);
            }
            public int Count
            {
                get { return item.Count; }
            }

            public object this[int index]
            {
                get { return item[index]; }
                set { item.Insert(index, value); }
            }
        }

        public static void invoke()
        {
            ConcreteAggregate a = new ConcreteAggregate();
            a[0] = "Item A";
            a[1] = "Item B";
            a[2] = "Item C";
            a[3] = "Item D";

            ConcreteIterator i = new ConcreteIterator(a);
            object item = i.First();
            while (item != null)
            {
                Console.WriteLine(item);
                item = i.Next();
            }

        }
    }
}
