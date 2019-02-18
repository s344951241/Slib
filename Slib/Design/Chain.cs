using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slib.Design
{
    public class Chain
    {

        public class Level {
            public int Lv;
        }
        public class Response {
            public string Name { get; set; }
        }
        public class Request {
            private Level lv;
            public Request(Level lv)
            {
                this.lv = lv;
            }
            public Level getRequestLevel()
            {
                return lv;
            }
        }
        public abstract class Handle
        {
            private Handle nextHandle;

            public abstract Response operaton(Request req);
            public abstract Level getHandleLevel();
            public Response handle(Request req)
            {
                Response res = null;
                if (this.getHandleLevel().Equals(req.getRequestLevel()))
                {
                    res = this.operaton(req);
                }
                else
                {
                    if (nextHandle != null)
                    {
                        Console.WriteLine("传给下一个链");
                        res = nextHandle.operaton(req);
                    }
                    else
                    {
                        Console.WriteLine("没有下一个链了");
                    }
                }
                return res;
            }
            public void setNext(Handle handle)
            {
                nextHandle = handle;
            }
        }

        public class ConcreteHandler1 : Handle
        {
            private Level lv;
            public ConcreteHandler1(Level lv)
            {
                this.lv = lv;
            }
            public override Level getHandleLevel()
            {
                return lv;
            }

            public override Response operaton(Request req)
            {
                Console.WriteLine("ConcreteHandler1执行责任");
                Response res = new Response();
                res.Name = "Response1";
                return res;
            }
        }

        public class ConcreteHandler2 : Handle
        {
            private Level lv;
            public ConcreteHandler2(Level lv)
            {
                this.lv = lv;
            }
            public override Level getHandleLevel()
            {
                return lv;
            }

            public override Response operaton(Request req)
            {
                Console.WriteLine("ConcreteHandler2执行责任");
                Response res = new Response();
                res.Name = "Response2";
                return res;
            }
        }

        public static void invoke()
        {
            Level lv1 = new Level { Lv = 1 };
            Level lv2 = new Level { Lv = 2 };
            Handle handle1 = new ConcreteHandler1(lv1);
            Handle handle2 = new ConcreteHandler2(lv2);

            handle1.setNext(handle2);

            Response res = handle1.handle(new Request(lv2));
            Console.WriteLine(res.Name);
        }
    }
}
