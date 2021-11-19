using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04
{
    public class FileUtilSimple
    {
        public static string[] ReadFile(string filePath)
        {
            List<string> lines = new List<string>();

            using (FileStream file = File.OpenRead(filePath))
            {
                StreamReader reader = new StreamReader(file, Encoding.UTF8);
                while (!reader.EndOfStream)
                {
                    lines.Add(reader.ReadLine());
                }
                reader.Close();
            }
            return lines.ToArray();
        }
    }
}
