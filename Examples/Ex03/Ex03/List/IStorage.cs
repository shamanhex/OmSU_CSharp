using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.List
{
    public interface IStorage<T>
    {
        void Add(T item);

        T Get(int i);
    }
}
