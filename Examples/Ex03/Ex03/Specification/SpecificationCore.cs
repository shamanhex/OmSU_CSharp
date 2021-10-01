using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.Specification
{
    public abstract class SpecificationCore<T> : ISpecification<T>
    {
        public abstract void IsValid(T value);

        public AndSpecification<T> And(ISpecification<T> spec)
        {
            return new AndSpecification<T>(this, spec);
        }
    }
}
