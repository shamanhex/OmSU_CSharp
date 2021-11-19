using Ex03.Specification;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.Test.Specification
{
    [TestFixture]
    public class IsNullSpecificationTest
    {
        [Test]
        public void IsNullSpecification_IsValid_NullArg()
        {
            new IsNullSpecification<object>().IsValid(null);
        }

        [Test]
        public void IsNullSpecification_IsValid_NotNullArg_thrValidationEx()
        {
            Assert.Throws<ValidationException>(() => {
                new IsNullSpecification<string>().IsValid("AAA");
            });
            
        }
    }
}
