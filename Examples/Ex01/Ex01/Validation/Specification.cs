using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01.Validation
{
    public abstract class Specification<T> : ISpecification<T>
    {
        public abstract void Validate(T value);

        public Specification<T> And(ISpecification<T> second)
        {
            return new AndSpecification<T>(this, second);
        }

        public Specification<T> Not()
        {
            return new NotSpecification<T>(this);
        }
    }
}
