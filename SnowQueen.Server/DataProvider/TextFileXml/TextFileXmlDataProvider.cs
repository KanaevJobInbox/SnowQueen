using System;
using System.IO;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using SnowQueen.Core.ObjectTypes;
using SnowQueen.Core.ObjectTypes.Extension;
using SnowQueen.Server.ServerException;
using System.Linq;

namespace SnowQueen.Server.DataProvider.TextFileXml
{
    class TextFileXmlDataProvider
    {
        readonly string PathFile = AppDomain.CurrentDomain.BaseDirectory + "DB\\SnowQueenTextFileXml.xml";

        //TODO Временное решение с Locker
       static object Locker = new object();

        public void AddProducts(IEnumerable<ObjectTypeProduct> products)
        {
            lock (Locker)
            {
                var actualProducts = GetProducts().JoinObjectTypeProduct(products);

                var xmlProducts = new List<XmlProduct>();
                foreach(var actualProduct in actualProducts)
                {
                    xmlProducts.Add(new XmlProduct() { Id = actualProduct.Id, Name = actualProduct.Name, Cost = actualProduct.Cost, Count = actualProduct.Count });
                }

                var xmlTextFile = new XmlTextFile();
                xmlTextFile.Products = xmlProducts.ToArray();

                try
                {
                    XmlSerializer xmlFormat = new XmlSerializer(typeof(XmlTextFile));

                    // Сохранить объект в локальном файле.
                    using (Stream fStream = new FileStream(PathFile,
                       FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        xmlFormat.Serialize(fStream, xmlTextFile);
                    }

                }
                catch (Exception ex)
                {
                    throw new TextFileXmlDataProviderException(ex.Message);
                }
            }
        }

        public IEnumerable<ObjectTypeProduct> GetProducts()
        {
            lock (Locker)
            {
                FileStream fs = null;
                try
                {
                    fs = new FileStream(PathFile, FileMode.Open);

                    TextReader reader = new StreamReader(fs);

                    XmlSerializer xmlFormat = new XmlSerializer(typeof(XmlTextFile));
                    XmlTextFile textFile = (XmlTextFile)xmlFormat.Deserialize(reader);

                    return textFile.Products?.Select(o => new ObjectTypeProduct()
                    { Id = o.Id, Name = o.Name, Cost = o.Cost, Count = o.Count, TypeProvaider = ObjectTypeEnumDataProvaider.XML })
                    .ToArray() ?? new ObjectTypeProduct[0];

                }
                catch (Exception ex)
                {
                    throw new TextFileXmlDataProviderException(ex.Message);
                }

                finally
                {
                    if (fs != null)
                    {
                        fs.Close();
                    }

                }
            }
        }
     
    }
}
