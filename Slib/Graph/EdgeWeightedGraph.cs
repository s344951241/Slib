using Slib.PriorityQueue;
using Slib.Search;
using System;
using System.Collections.Generic;

namespace Slib.Graph
{
    //加权无向图
    public class Edge : IComparable<Edge>
    {
        private int m_V;//顶点之一
        private int m_W;//另一个顶点
        private double m_Weight;//边的权重

        public Edge(int v, int w, double weight)
        {
            m_V = v;
            m_W = w;
            m_Weight = weight;
        }

        public double weight()
        {
            return m_Weight;
        }
        public int either()
        {
            return m_V;
        }
        public int other(int vertex)
        {
            if (vertex == m_V)
                return m_W;
            else if (vertex == m_W)
                return m_V;
            else
                throw new Exception("Inconsistent edge");
        }

        public int CompareTo(Edge other)
        {
            if (m_Weight < other.weight())
                return -1;
            else if (m_Weight > other.weight())
                return 1;
            else
                return 0;
        }
        public override string ToString()
        {
            return string.Format("%d-%d %.2f", m_V, m_W, m_Weight);
        }
    }

    public class EdgeWeightedGraph
    {
        private int m_V;
        private int m_E;
        private List<Edge>[] m_Adj;

        public EdgeWeightedGraph(int v)
        {
            m_V = v;
            m_E = 0;
            m_Adj = new List<Edge>[v];
            for (int i = 0; i < v; i++)
            {
                m_Adj[i] = new List<Edge>();
            }

        }

        public int V()
        {
            return m_V;
        }

        public int E()
        {
            return m_E;
        }

        public void addEdge(Edge e)
        {
            int v = e.either();
            int w = e.other(v);
            m_Adj[v].Add(e);
            m_Adj[w].Add(e);
            m_E++;
        }

        public List<Edge> adj(int v)
        {
            return m_Adj[v];
        }

        public List<Edge> edges()
        {
            List<Edge> list = new List<Edge>();
            for (int v = 0; v < m_V; v++)
            {
                foreach (Edge e in m_Adj[v])
                {
                    if (e.other(v) > v)
                        list.Add(e);
                }
            }
            return list;
        }
    }

    public class LazyPrimMST
    {
        private bool[] m_Marked;//最小生成树的顶点
        private Queue<Edge> m_Mst;//最小生成树的边
        private MinPQ<Edge> m_Pq;//横切边
        private double m_Weight;

        public LazyPrimMST(EdgeWeightedGraph g)
        {
            m_Pq = new MinPQ<Edge>();
            m_Marked = new bool[g.V()];
            m_Mst = new Queue<Edge>();

            visit(g, 0);
            while (!(m_Pq.isEmpty()))
            {
                Edge e = m_Pq.delMin();
                int v = e.either();
                int w = e.other(v);
                if (m_Marked[v] && m_Marked[w])
                {
                    continue;
                }
                m_Mst.Enqueue(e);
                m_Weight += e.weight();
                if (!m_Marked[v])
                {
                    visit(g, v);
                }
                if (!m_Marked[w])
                {
                    visit(g, w);
                }
            }

        }

        private void visit(EdgeWeightedGraph g, int v)
        {
            m_Marked[v] = true;
            foreach (Edge e in g.adj(v))
            {
                m_Pq.insert(e);
            }
        }

        public Queue<Edge> edgs()
        {
            return m_Mst;
        }

        public double weight()
        {
            return m_Weight;
        }
    }
    public class PrimMST {
        private Edge[] m_EdgeTo;
        private double[] m_DistTo;
        private bool[] m_Marked;
        private IndexMinPQ<double> m_Pq;

        public PrimMST(EdgeWeightedGraph g)
        {
            m_EdgeTo = new Edge[g.V()];
            m_DistTo = new double[g.V()];
            m_Marked = new bool[g.V()];

            for (int v = 0; v < g.V(); v++)
            {
                m_DistTo[v] = double.PositiveInfinity;
            }
            m_Pq = new IndexMinPQ<double>(g.V());
            m_DistTo[0] = 0.0;
            m_Pq.insert(0, 0.0);
            while (!m_Pq.isEmpty())
            {
                visit(g, m_Pq.delMin());
            }
        }

        private void visit(EdgeWeightedGraph G, int v)
        {
            m_Marked[v] = true;
            foreach (Edge e in G.adj(v))
            {
                int w = e.other(v);

                if (m_Marked[w])
                {
                    continue;
                }
                if (e.weight() < m_DistTo[w])
                {
                    m_EdgeTo[w] = e;

                    m_DistTo[w] = e.weight();
                    if (m_Pq.contains(w))
                    {
                        m_Pq.changeKey(w, m_DistTo[w]);
                    }
                    else
                    {
                        m_Pq.insert(w, m_DistTo[w]);
                    }
                }
            }
        }
        public List<Edge> edgs()
        {
            List<Edge> mst = new List<Edge>();
            for (int i = 1; i < m_EdgeTo.Length; i++)
            {
                mst.Add(m_EdgeTo[i]);
            }
            return mst;
        }

        public double weight()
        {
            double weight = 0;
            for (int i = 0; i < m_DistTo.Length; i++)
            {
                weight += m_DistTo[i];
            }
            return weight;
        }
    }

    public class KruskalMST
    {
        private Queue<Edge> _mst;
        private double _weight;
        public KruskalMST(EdgeWeightedGraph g)
        {
            _mst = new Queue<Edge>();
            MinPQ<Edge> pq = new MinPQ<Edge>(g.edges().ToArray());
            foreach (Edge e in g.edges())
            {
                pq.insert(e);
            }
            UnionFind uf = new UnionFind(g.V());
            while (!pq.isEmpty() && _mst.Count < g.V() - 1)
            {
                Edge e = pq.delMin();
                int v = e.either();
                int w = e.other(v);
                if (uf.Connected(v, w))
                {
                    continue;
                }
                uf.Union(v, w);
                _mst.Enqueue(e);
                _weight += e.weight();
            }
        }

        public IEnumerable<Edge> edges()
        {
            return _mst;
        }

        public double weight()
        {
            return _weight;
        }
    }
}
