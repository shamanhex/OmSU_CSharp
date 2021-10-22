using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.Specification;

namespace Ex03
{
    class A
    {
        public void PrintA1()
        {
            Console.WriteLine("A1");
        }

        public virtual void PrintA2()
        {
            Console.WriteLine("A2");
        }
    }

    class B : A
    {
        public new void PrintA1()
        {
            Console.WriteLine("B1");
        }
        public override void PrintA2()
        {
            Console.WriteLine("B2");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("Россия", "Москва");

            B b = new B();
            A a = (A)b;

            b.PrintA1();
            b.PrintA2();

            a.PrintA1();
            a.PrintA2();

            Console.ReadLine();
        }

    }
}
