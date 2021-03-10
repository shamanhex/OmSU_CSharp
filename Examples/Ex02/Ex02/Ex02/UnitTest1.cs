using NUnit.Framework;
using System;
using System.Text;

namespace Ex02
{
    public class Tests
    {
        [Test]
        public void Arithmetic()
        {
            Assert.AreEqual(4, 2+2);
        }

        [Test]
        public void Int_DivByZero()
        {
            try
            {
                int zero = 0;
                int result = 1 / zero;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(Convert.ToString(ex));
            }
            finally
            {
                Assert.Pass();
            }
        }

        [Test]
        public void Double_DivByZero()
        {
            double zero = 0.0;
            Assert.AreEqual(double.PositiveInfinity, 1.0 / zero);
        }

        [Test]
        public void String_BaseOperations()
        {
            string s1 = "aaa";
            string s2 = "bbb";
            string s3 = s1 + s2;
            string s4 = "aaabbb";

            Assert.AreEqual(s4, s3);
            Assert.IsTrue(object.ReferenceEquals(s4, "aaabbb"));

            Assert.IsFalse(object.ReferenceEquals(s4, s3));
            s3 = string.Intern(s3);
            Assert.IsTrue(object.ReferenceEquals(s4, s3));

            Assert.AreEqual(s1, s4.Substring(0, 3));
            Assert.AreEqual(0, s4.IndexOf(s1));
        }

        [Test]
        public void StringBuilder_BaseOperations()
        {
            StringBuilder s1 = new StringBuilder("aaa");
            StringBuilder s2 = new StringBuilder("bbb");
            StringBuilder s3 = new StringBuilder();
            s3.Append(s1);
            s3.Append(s2);
            StringBuilder s4 = new StringBuilder("aaabbb");

            Assert.AreEqual(s4.ToString(), Convert.ToString(s3));

            StringBuilder s10 = new StringBuilder();
            s10.AppendFormat("s1 = {0}; ", s1);
            s10.AppendFormat("s2 = {0}; ", 100);
            s10.AppendFormat("s3 = {0}; ", s3);
            Console.WriteLine(Convert.ToString(s10));
        }
    }
}