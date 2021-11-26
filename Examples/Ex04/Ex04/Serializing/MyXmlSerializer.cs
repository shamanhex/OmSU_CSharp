using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Ex04.Serializing
{
    public class MyXmlSerializer
    {
        public static void Save<T>(string fileName, T data)
        {
            XmlDocument xml = new XmlDocument();

            string className = typeof(T).Name;
            XmlElement root = xml.CreateElement(className);
            xml.AppendChild(root);

            foreach (FieldInfo field in typeof(T).GetFields())
            {
                string fieldName = field.Name;
                object fieldValue = field.GetValue(data);
                string fieldValueString = Convert.ToString(fieldValue);
                
                XmlElement fieldNode = xml.CreateElement("field");
                fieldNode.SetAttribute("name", fieldName);
                fieldNode.SetAttribute("value", fieldValueString);

                root.AppendChild(fieldNode);
            }

            xml.Save(fileName);
        }
    }
}
