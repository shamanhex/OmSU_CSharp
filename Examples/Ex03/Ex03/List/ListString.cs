using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.List
{
    public class MyList<T> : Storage<T>
    {
        public MyList()
        {

        }

        public void Remove(int i)
        {
            _list.RemoveAt(i);
        }
    }

    public class ListString : Storage<string>
    {
        public ListString()
        {

        }

        public void Remove(int i)
        {
            _list.RemoveAt(i);
        }
    }
}
