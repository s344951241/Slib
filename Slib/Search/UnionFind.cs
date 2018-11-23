namespace Slib.Search
{
    public class UnionFind
    {
        private int[] _id;
        private int _count;

        public UnionFind(int n)
        {
            _count = n;
            _id = new int[n];
            for (int i = 0; i < n; i++)
            {
                _id[i] = i;
            }
        }

        public int Count()
        {
            return _count;
        }

        public bool Connected(int p, int q)
        {
            return Find(p) == Find(q);
        }
        public int Find(int p)
        {
            while (p != _id[p])
            {
                p = _id[p];
            }
            return p;
        }

        public void Union(int p, int q)
        {
            int pRoot = Find(p);
            int qRoot = Find(q);
            if (pRoot == qRoot)
            {
                return;
            }
            _id[pRoot] = qRoot;
            _count--;
        }
    }
}
