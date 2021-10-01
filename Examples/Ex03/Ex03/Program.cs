using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.Specification;

namespace Ex03
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SpecificationCore<string> IsNullString = new IsNullSpecification<string>();
                SpecificationCore<string> IsNotEmpty = new IsNotEmptySpecification();
                SpecificationCore<string> spec = IsNullString.And(IsNotEmpty);
            }
            catch (ValidationException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("");
            }

            MyList<string> StringList = new MyList<string>();
            StringList.OnAdd += (sender, item) =>
            {
                Console.WriteLine(item + " added to list. " + StringList.Count());
            };
            StringList.Add("s1");
            StringList.Add("s2");
                                                          

            double x = 10;
            double y = 10;

            DateTime d1 = new DateTime(2021, 01, 31), d2;
            Console.WriteLine(d1.AddMonths(1));

            double z = (double)-10 / (double)0;
            Console.WriteLine("{0}", z);

            if (Math.Abs(x - y) < Double.Epsilon)
            {
                //Console.Write("{0}");
            }
            Console.ReadLine();
        }

        public static void IsNull(object obj)
        {
            if (obj != null)
            {
                throw new ValidationException("Object is not null");
            }
        }

        public static void handler(object sender, string item)
        {
            Console.WriteLine(item + " add to list");
        }
    }
}
