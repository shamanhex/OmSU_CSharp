using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.Specification
{
    public class IsNullSpecification<T>: SpecificationCore<T>
    {
        public override void IsValid(T value)
        {
            if (value != null)
            {
                throw new ValidationException("value is not null");
            }
        }
    }
}
