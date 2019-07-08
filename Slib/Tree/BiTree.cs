using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slib.Tree
{
    public class BiTree<T>
    {
        private T _data;
        private BiTree<T> _lchild, _rchild;
        public delegate void EACH_INVOKE(BiTree<T> tree);
        public BiTree(T val, BiTree<T> lp, BiTree<T> rp)
        {
            _data = val;
            _lchild = lp;
            _rchild = rp;
        }
        public BiTree(T val)
        {
            _data = val;
            _lchild = null;
            _rchild = null;
        }

        public BiTree()
        {
            _data = default(T);
            _lchild = null;
            _rchild = null;
        }

        public T Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public BiTree<T> LChild
        {
            get { return _lchild; }
            set { _lchild = value; }
        }

        public BiTree<T> RChild
        {
            get { return _rchild; }
            set { _rchild = value; }
        }

        public virtual void  PreOrderTraverse(EACH_INVOKE fun = null)
        {
            if (fun == null)
            {
                return;
            }
            fun.Invoke(this);
            if (_lchild != null)
            {
                _lchild.PreOrderTraverse(fun);
            }
            if (_rchild != null)
            {
                _rchild.PreOrderTraverse(fun);
            }
           
        }

        public virtual void InOrderTraverse(EACH_INVOKE fun = null)
        {
            if (fun == null)
            {
                return;
            }
            if (_lchild != null)
            {
                _lchild.InOrderTraverse(fun);
            }
        
            fun.Invoke(this);
            if (_rchild != null)
            {
                _rchild.InOrderTraverse(fun);
            }
        }

        public void PostOrderTraverse(EACH_INVOKE fun = null)
        {
            if (fun == null)
            {
                return;
            }
            if (_lchild != null)
            {
                _lchild.PostOrderTraverse(fun);
            }
            if (_rchild != null)
            {
                _rchild.PostOrderTraverse(fun);
            }
            fun.Invoke(this);
        }
    }
}
