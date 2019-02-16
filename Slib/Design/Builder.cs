using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slib.Design
{
    public class BuilderModel
    {
        public class Product
        {
            public string Name { set; get; }
            public string Id { set; get; }
            public string Info { set; get; }

        }

        public abstract class Builder
        {
            public abstract void BuildName();
            public abstract void BuildId();
            public abstract void BuildInfo();
            public abstract Product BuildProduct();
        }

        public class ConcreteBuilder : Builder
        {
            private Product product = new Product();
            public override void BuildId()
            {
                product.Id = "00001";
            }
            public override void BuildName()
            {
                product.Name = "Product";
            }
            public override void BuildInfo()
            {
                product.Info = "这是一个product";
            }
            public override Product BuildProduct()
            {
                return product;
            }
        }
        public class Director
        {
            private Builder m_builder;
            public Director(Builder builder)
            {
                m_builder = builder;
            }

            public Product build()
            {
                m_builder.BuildId();
                m_builder.BuildName();
                m_builder.BuildInfo();
                return m_builder.BuildProduct();
            }
        }

        public static void invoke()
        {
            Director director = new Director(new ConcreteBuilder());
            Product product = director.build();
            Console.WriteLine(product.Id + product.Name + product.Info);
        }
    }
}
