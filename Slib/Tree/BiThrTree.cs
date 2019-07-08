using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slib.Tree
{
    public class BiThrTree<T>
    {
        public delegate void EACH_INVOKE(BiThrTree<T> tree);

        private T _data;
        private bool _lTag;
        private bool _RTag;

        private BiThrTree<T> _lchild, _rchild;

        BiThrTree<T> pre;

        public void InThreading()
        {
            _lchild.InThreading();
            if (_lchild == null)
            {
                _lTag = true;
                _lchild = pre;
            }
            if (_rchild == null)
            {
                _RTag = true;
                _rchild = this;
            }
            pre = this;
            _rchild.InThreading();
        }

        public void InOrderTraverse_Thr(EACH_INVOKE fun = null)
        {
            if (fun == null)
                return;
            BiThrTree<T> p = _lchild;
            while (p != this)
            {
                while (p._lTag == false)
                {
                    p = p._lchild;
                }
            }
            fun(p);
            while (p._RTag == true && p._rchild != this)
            {
                p = p._rchild;
                fun(p);
            }
            p = p._rchild;
        }
    }
}
