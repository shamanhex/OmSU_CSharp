using System;
using System.Collections.Generic;
using System.Text;
using Ex03.Specification;
using NUnit.Framework;

namespace Ex03.Test.Specification
{
    [TestFixture]
    public class IsIPSpecificationTest
    {
        [Test]
        public void IsIPSpecification_IsValid_LocalhostIP()
        {
            new IsIPSpecification().IsValid("127.0.0.1");
        }

        [Test]
        public void IsIPSpecification_IsValid_NonIP_thrValidationEx()
        {
            Assert.Throws<ValidationException>(() =>
            {
                new IsIPSpecification().IsValid("127.0.0.o");
            });            
        }
    }
}
