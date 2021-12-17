using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ex04.Serializing
{
    [Serializable]
    public class Config
    {
        [XmlElement(ElementName = "DBAddress")]
        public string DataBaseServerAddress;

        [XmlElement(ElementName = "DBName")]
        public string DataBaseName;

        [XmlElement(ElementName = "DBUser")]
        public string UserName;

        [XmlElement(ElementName = "DBPass")]
        public string Password;
        public int TimeOut;
        public double Devider;
        public DateTime ExpirationDate;

        public string ConnectionString
        {
            get
            {
                return string.Format("server={0};database={1};", this.DataBaseServerAddress, this.DataBaseName);
            }
        }
    }
}

/*
 *  <Config>
 *      <field name="DataBaseServerAddress" value="127.0.0.1" />
 *      ...
 *  <Config>
 * 
 */
