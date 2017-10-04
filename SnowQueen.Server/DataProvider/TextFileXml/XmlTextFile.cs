using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SnowQueen.Server.DataProvider.TextFileXml
{
    [XmlRoot(ElementName = "XmlTextFile")]
    public class XmlTextFile
    {
        [XmlArray(ElementName = "Products")]
        [XmlArrayItem(ElementName = "Product")]
        public XmlProduct[] Products { get; set; }

    }
}
