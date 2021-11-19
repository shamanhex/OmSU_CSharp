using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Ex04
{
    public class XMLUtil
    {
        public static string ReadMessage(string filePath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            XmlElement root = doc.DocumentElement;
            XmlNode appSettingsNode = root.GetElementsByTagName("appSettings").Item(0);
            foreach (XmlNode appSettingsLine in appSettingsNode.ChildNodes)
            {
                if (string.Compare(appSettingsLine.Attributes["key"].Value, "Message", true) == 0)
                {
                    return appSettingsLine.Attributes["value"].Value;
                }
            }
            return null;
        }
    }
}
