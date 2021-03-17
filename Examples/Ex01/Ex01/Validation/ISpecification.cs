using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01.Validation
{
    public interface ISpecification<T>
    {
        void Validate(T value);
    }

    public class AndSpecification<T> : Specification<T>
    {
        ISpecification<T> spec1 = null, spec2 = null;

        public AndSpecification(ISpecification<T> s1, ISpecification<T> s2)
        {
            spec1 = s1;
            spec2 = s2;
        }

        public override void Validate(T value)
        {
            spec1.Validate(value);
            spec2.Validate(value);
        }
    }

    public class NotSpecification<T> : Specification<T>
    {
        ISpecification<T> spec = null;

        public NotSpecification(ISpecification<T> s)
        {
            spec = s;
        }

        public override void Validate(T value)
        {
            try
            {
                spec.Validate(value);
            }
            catch (ValidationException)
            {

            }
            throw new ValidationException("Exception was not generated.");
        }
    }
}
