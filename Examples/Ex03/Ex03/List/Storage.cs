using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.List
{
    public class Storage<T> : IStorage<T>
    {
        protected List<T> _list = new List<T>();

        public Storage()
        {

        }

        public void Add(T item)
        {
            _list.Add(item);
        }

        public T Get(int i)
        {
            return _list[i];
        }

        public int Count
        {
            get
            {
                return this._list.Count;
            }
        }
    }
}
