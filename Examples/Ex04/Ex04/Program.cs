using Ex04.Serializing;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

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

            Console.WriteLine("============================ Save using Serializer ============================");
            Config cfg = new Config()
            {
                DataBaseServerAddress = "127.0.0.1",
                DataBaseName = "Employees",
                TimeOut = 100000,
                Devider = 3.14,
                ExpirationDate = new DateTime(2020, 10, 20)
            };
            string xmlConfigPath = Path.Combine(configFolder, "config.MyXmlSerializer.xml");
            MyXmlSerializer.Save<Config>(xmlConfigPath, cfg);
            Console.WriteLine(" {0} saved", xmlConfigPath);

            xmlConfigPath = Path.Combine(configFolder, "config.XmlSerializer.xml");
            XmlSerializer XmlSerializer = new XmlSerializer(typeof(Config));
            using (FileStream fs = new FileStream(xmlConfigPath, FileMode.OpenOrCreate))
            {
                XmlSerializer.Serialize(fs, cfg);
            }
            Console.WriteLine(" {0} saved", xmlConfigPath);

            string jsonConfigPath = Path.Combine(configFolder, "config.JsonSerializer.json");
            JsonSerializer jsonSerializer = new JsonSerializer();
            using (StreamWriter jsonFile = new StreamWriter(jsonConfigPath))
            using (JsonWriter jsonWriter = new JsonTextWriter(jsonFile))
            {
                jsonSerializer.Serialize(jsonWriter, cfg);
            }
            Console.WriteLine(" {0} saved", jsonConfigPath);

            Console.WriteLine("============================ Load using Serializer ============================");
            string jsonConfigFile = Path.Combine(configFolder, "config.json");
            using (StreamReader reader = new StreamReader(jsonConfigFile))
            using (JsonReader jsonReader = new JsonTextReader(reader))
            {
                Config config = jsonSerializer.Deserialize<Config>(jsonReader);
                Console.WriteLine("Load {0}", jsonConfigFile);
                Console.WriteLine("config.DataBaseServerAddress = {0}", config.DataBaseServerAddress);
            }
        }
    }
}
