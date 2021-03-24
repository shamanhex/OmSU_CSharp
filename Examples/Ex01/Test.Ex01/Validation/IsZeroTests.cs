using System;
using System.Collections.Generic;
using System.Text;
using Ex01.Validation;
using NUnit.Framework;

namespace Test.Ex01.Validation
{
    [TestFixture]
    public class IsZeroTests
    {
        [Test]
        public void IsZero_Validate_wZero()
        {
            new IsZero().Validate(0);
        }

        [Test]
        public void IsZero_Validate_wNonZero_throwValidationEx()
        {
            Assert.Throws<ValidationException>(() => new IsZero().Validate(10));            
        }
    }
}
