using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.Specification
{
    public interface ISpecification<T>
    {
        void IsValid(T value);
    }
}
