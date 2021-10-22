using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03
{
    public class MyList<T>
    {
        public delegate void ItemHandler(object sender, T item);
        public event ItemHandler OnAdd;
        public event ItemHandler OnDelete;

        public void FireAdd(T item)
        {
            if (OnAdd != null)
            {
                OnAdd(this, item);
            }
        }

        List<T> list = new List<T>();

        public void Add(T item)
        {
            FireAdd(item);
            list.Add(item);
        }

        public int Count()
        {
            return list.Count;
        }
    }
}
