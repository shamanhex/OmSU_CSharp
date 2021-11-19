using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ex04
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = Assembly.GetEntryAssembly().Location + ".config";
            Console.WriteLine(filePath);

            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not exists");
                return;
            }
            Console.WriteLine("File exist");
            Console.WriteLine("Folder exist: {0}", (Directory.Exists(filePath) ? "YES" : "NO"));

            string configFolder = Path.GetDirectoryName(filePath);
            Console.WriteLine(configFolder);
            Console.WriteLine("Folder exist: {0}", (Directory.Exists(configFolder) ? "YES" : "NO"));
            Console.WriteLine("File exist: {0}", (File.Exists(configFolder) ? "YES" : "NO"));

            Console.WriteLine("============================ Content ============================");

            //string[] lines = FileUtilSimple.ReadFile(filePath);
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("");
            Console.WriteLine("Write backup...");
            File.WriteAllLines(filePath + ".bak", lines, Encoding.UTF8);

            Console.WriteLine("============================ Get message from XML ============================");
            Console.WriteLine(XMLUtil.ReadMessage(filePath));

            Console.WriteLine("============================ Get message from .config ============================");
            Console.WriteLine(ConfigurationManager.AppSettings["Message"]);
        }
    }
}
