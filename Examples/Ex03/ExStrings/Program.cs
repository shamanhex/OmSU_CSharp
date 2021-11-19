using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = "A";
            string str2 = "B";
            string str3 = "AB";

            Console.WriteLine(Object.ReferenceEquals(str3, String.Intern(str1 + str2)));
            Console.ReadLine();

            object obj = null;
            obj.ToString();
            Convert.ToString(obj);

            string path1 = "C:\\Path" + obj;
            string path2 = "C:\\path\\";
            
            if (string.Compare(path1, path2, ignoreCase:true) == 0)
            {

            }

            str1 = (str1 == null) ? null : str1.Trim();
            Console.WriteLine("{0}", str1 ?? "<null>");
        }
    }
}
