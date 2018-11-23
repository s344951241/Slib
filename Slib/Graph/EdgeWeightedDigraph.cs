using Slib.PriorityQueue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slib.Graph
{
    public class DirectedEdge
    {
        private int _v;//起点
        private int _w;//终点

        private double _weight;//权重

        public DirectedEdge(int v, int w, double weight)
        {
            _v = v;
            _w = w;
            _weight = weight;

        }

        public double weight()
        {
            return _weight;
        }
        public int from()
        {
            return _v;
        }
        public int to()
        {
            return _w;
        }
        public override string ToString()
        {
            return string.Format("%d->%d %.2f", _v, _w, _weight);
        }
    }
    public class EdgeWeightedDigraph
    {
        private int _V;
        private int _E;
        private List<DirectedEdge>[] _adj;

        public EdgeWeightedDigraph(int v)
        {
            _V = v;
            _E = 0;
            _adj = new List<DirectedEdge>[v];
            for (int i = 0; i < v; i++)
            {
                _adj[i] = new List<DirectedEdge>();
            }
        }

        public int V()
        {
            return _V;
        }
        public int E()
        {
            return _E;
        }
        public void addEdge(DirectedEdge e)
        {
            _adj[e.from()].Add(e);
            _E++;
        }
        public List<DirectedEdge> adj(int v)
        {
            return _adj[v];
        }
        public List<DirectedEdge> edges()
        {
            List<DirectedEdge> list = new List<DirectedEdge>();
            for (int i = 0; i < _V; i++)
            {
                foreach (DirectedEdge e in _adj[i])
                {
                    list.Add(e);
                }
            }
            return list; 
        }

        public override string ToString()
        {
            String s = _V + " vertices, " + _E + " edges\n";
            for (int i = 0; i < _V; i++)
            {
                s += i + ": ";
                foreach (DirectedEdge e in this.adj(i))
                {
                    s += e + " ";
                }
                s += "\n";
            }
            return s;
        }

    }

    public class DijistraSP
    {
        private DirectedEdge[] _edgeTo;
        private double[] _distTo;
        private IndexMinPQ<double> _pq;

        public DijistraSP(EdgeWeightedDigraph g, int s)
        {
            _edgeTo = new DirectedEdge[g.V()];
            _distTo = new double[g.V()];
            _pq = new IndexMinPQ<double>(g.V());

            for (int i = 0; i < g.V(); i++)
            {
                _distTo[i] = double.PositiveInfinity;
            }
            _distTo[s] = 0.0;
            _pq.insert(s, 0.0);
            while (!_pq.isEmpty())
            {
                relax(g, _pq.delMin());
            }
        }
        private void relax(EdgeWeightedDigraph g, int v)
        {
            foreach (DirectedEdge e in g.adj(v))
            {
                int w = e.to();
                if (_distTo[w] > _distTo[v] + e.weight())
                {
                    _distTo[w] = _distTo[v] + e.weight();
                    _edgeTo[w] = e;
                    if (_pq.contains(w))
                    {
                        _pq.changeKey(w, _distTo[w]);
                    }
                    else
                    {
                        _pq.insert(w, _distTo[w]);
                    }
                }
            }
        }

        public double distTo(int v)
        {
            return _distTo[v];
        }

        public bool hasPathTo(int v)
        {
            return _distTo[v] < double.PositiveInfinity;
        }
        public IEnumerable<DirectedEdge> pathTo(int v)
        {
            if (!hasPathTo(v))
                return null;
            Stack<DirectedEdge> path = new Stack<DirectedEdge>();
            for (DirectedEdge e = _edgeTo[v]; e != null; e = _edgeTo[e.from()])
            {
                path.Push(e);
            }
            return path;
        }

    }
}
