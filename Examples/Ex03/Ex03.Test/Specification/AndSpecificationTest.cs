using NUnit.Framework;
using Ex03.Specification;

namespace Ex03.Test.Specification
{
    [TestFixture]
    public class AndSpecificationTest
    {
        [Test]
        public void AndSpecification_IsValid_1of2SpecsIsTrue_thrValidationException()
        {
            ISpecification<string> isNotEmptySpec = new IsNotEmptySpecification();
            ISpecification<string> isNullSpec = new IsNullSpecification<string>();
            AndSpecification<string> andSpec = new AndSpecification<string>(isNotEmptySpec, isNullSpec);

            Assert.Throws<ValidationException>(() => { andSpec.IsValid(""); });
        }
    }

}