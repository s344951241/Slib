using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slib.Tree
{
    public class Tree<T>
    {
        public Tree()
        {
            _nodes = new List<Tree<T>>();

        }
        public Tree(T data)
        {
            Data = data;
            _nodes = new List<Tree<T>>();
        }

        /// <summary>
        /// 结点数据
        /// </summary>
        public T Data { get; set; }

        private List<Tree<T>> _nodes;
        /// <summary>
        /// 子结点
        /// </summary>
        public List<Tree<T>> Nodes
        {
            get { return _nodes; }
        }

        private Tree<T> _parent;
        public Tree<T> Parent
        {
            get { return _parent; }
        }

        public void AddNode(Tree<T> node)
        {
            if (!_nodes.Contains(node))
            {
                _nodes.Add(node);
            }
        }

        public void AddNode(List<Tree<T>> nodes)
        {
            foreach (var node in nodes)
            {
                node._parent = this;
                nodes.Add(node);
            }
        }
        public void Remove(Tree<T> node)
        {
            if (_nodes.Contains(node))
            {
                _nodes.Remove(node);
            }
        }

        public void RemoveAll()
        {
            _nodes.Clear();
        }
    }
}
