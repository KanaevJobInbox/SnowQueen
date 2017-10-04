using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using SnowQueen.Core.ObjectTypes;

namespace SnowQueen.Server.DataProvider.TextFileXml
{
    [XmlRoot(ElementName = "Product")]
   public class XmlProduct 
    {
        [XmlAttribute(AttributeName = "Id")]
        public Guid Id
        { get; set; }
        [XmlElement(ElementName = "Name")]
        public string Name
        { get; set; }
        [XmlElement(ElementName = "Cost")]
        public int Cost
        { get; set; }
        [XmlElement(ElementName = "Count")]
        public int Count
        { get; set; }
    }
}
