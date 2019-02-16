using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slib.Design
{

    public class ProductBase
    {
        public string Name { private set; get; }
        public ProductBase(string name)
        {
            Name = name;
        }
    }

    public class ProductA : ProductBase
    {
        public ProductA(string name) : base(name)
        {

        }
    }

    public class ProductB : ProductBase
    {
        public ProductB(string name) : base(name)
        {

        }
    }

    public class SimpleFactory {
        public class Factory
        {
            public static ProductBase create(int type)
            {
                ProductBase product = null;
                switch (type)
                {
                    case 1:
                        product = new ProductA("Product A");
                        break;
                    case 2:
                        product = new ProductB("product B");
                        break;
                }
                return product;
            }
        }
        public static void invoke()
        {
            ProductBase product = Factory.create(1);
            Console.WriteLine("生产了产品:" + product.Name);
            product = Factory.create(2);
            Console.WriteLine("生产了产品:" + product.Name);
        }
    }

    public class Factory
    {
        public abstract class FactoryBase
        {
            public abstract ProductBase create();
        }
        public class FactoryA : FactoryBase
        {
            public override ProductBase create()
            {
                return new ProductA("procuct A");
            }
        }

        public class FactoryB : FactoryBase
        {
            public override ProductBase create()
            {
                return new ProductB("product B");
            }
        }
        public static void invoke()
        {
            ProductBase product = new FactoryA().create();
            Console.WriteLine("生产了产品：" + product.Name);
            product = new FactoryB().create();
            Console.WriteLine("生产了产品: " + product.Name);
        }
    }
    public class AbstractFactory
    {
        public abstract class ProductBaseA
        {
            public void shareMethod() { }
            public abstract void operation();
        }
        public abstract class ProductBaseB
        {
            public void shareMethod() { }
            public abstract void operation();
        }

        public class ProductA1 : ProductBaseA
        {
            public override void operation()
            {
                Console.WriteLine("执行productA1的方法");
            }
        }

        public class ProductA2 : ProductBaseA
        {
            public override void operation()
            {
                Console.WriteLine("执行productA2的方法");
            }
        }
        public class ProductB1 : ProductBaseB
        {
            public override void operation()
            {
                Console.WriteLine("执行productB1的方法");
            }
        }
        public class ProductB2 : ProductBaseB
        {
            public override void operation()
            {
                Console.WriteLine("执行productB2的方法");
            }
        }


        public abstract class Factory
        {
            public abstract ProductBaseA createA();
            public abstract ProductBaseB createB();
        }

        public class Factory1 : Factory
        {
            public override ProductBaseA createA()
            {
                return new ProductA1();
            }

            public override ProductBaseB createB()
            {
                return new ProductB1();
            }
        }

        public class Factory2 : Factory
        {
            public override ProductBaseA createA()
            {
                return new ProductA2();
            }

            public override ProductBaseB createB()
            {
                return new ProductB2();
            }
        }

        public static void invoke()
        {
            Factory factory1 = new Factory1();
            Factory factory2 = new Factory2();

            ProductBaseA A1 = factory1.createA();
            ProductBaseA A2 = factory2.createA();
            ProductBaseB B1 = factory1.createB();
            ProductBaseB B2 = factory2.createB();
            A1.operation();
            A2.operation();
            B1.operation();
            B2.operation();


            FactoryOne one = new FactoryOne();
            Product product = new Product(one.createPartA(), one.createPartB());
            Console.WriteLine(product);
        }


        ///-------------------------------------------
        public class Product
        {
            public ProductA PartA { private set; get; }
            public ProductB PartB { private set; get; }
            public Product(ProductA a, ProductB b)
            {
                PartA = a;
                PartB = b;
            }
            public override string ToString()
            {
                return "由" + PartA.Name + "和" + PartB.Name + "构成的产品";
            }
        }

        public abstract class FactoryOther
        {
            public abstract ProductA createPartA();
            public abstract ProductB createPartB();
        }

        public class FactoryOne : FactoryOther
        {
            public override ProductA createPartA()
            {
                return new ProductA("One工厂生产的partA");
            }

            public override ProductB createPartB()
            {
                return new ProductB("one工厂生产的partB");
            }
        }
    }
  
}
