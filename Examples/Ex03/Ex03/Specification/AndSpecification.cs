using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.Specification
{
    public class AndSpecification<T> : SpecificationCore<T>
    {
        ISpecification<T> spec1 = null;
        ISpecification<T> spec2 = null;

        public AndSpecification(ISpecification<T> s1, ISpecification<T> s2)
        {
            spec1 = s1;
            spec2 = s2;
        }

        public override void IsValid(T value)
        {
            spec1.IsValid(value);
            spec2.IsValid(value);
        }
    }
}
