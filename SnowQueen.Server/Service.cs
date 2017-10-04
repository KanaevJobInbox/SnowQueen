using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnowQueen.Core.Contract;
using SnowQueen.Core.ObjectTypes;
using SnowQueen.Core.ObjectTypes.Extension;
using SnowQueen.Server.DataProvider.SQLite;
using SnowQueen.Server.DataProvider.TextFileXml;

namespace SnowQueen.Server
{
    class Service : IContractAddEndGet
    {

        private SQLiteDataProvider providerSQLite = new SQLiteDataProvider();
        private TextFileXmlDataProvider providerTextXml = new TextFileXmlDataProvider();

        /// <summary>
        /// Добавление продукта
        /// </summary>
        /// <param name="products">Коллекция продуктов</param>
        /// <param name="typeProvaider">Тип провайдера</param>
        public void AddProducts(IEnumerable<ObjectTypeProduct> products, ObjectTypeEnumDataProvaider typeProvaider)
        {
            switch (typeProvaider)
            {
                case ObjectTypeEnumDataProvaider.ALL:
                    providerSQLite.AddProducts(products);
                    providerTextXml.AddProducts(products);
                    break;
                case ObjectTypeEnumDataProvaider.SQLite:
                    providerSQLite.AddProducts(products);
                    break;
                case ObjectTypeEnumDataProvaider.XML:
                    providerTextXml.AddProducts(products);
                    break;
                default:
                    Console.WriteLine("Default case");
                    return; //TODO Exception
            }

        }

        /// <summary>
        /// Получение списка продуктов
        /// </summary>
        /// <param name="typeProvaider">Тип провайдера</param>
        public IEnumerable<ObjectTypeProduct> GetProducts(ObjectTypeEnumDataProvaider typeProvaider)
        {
            switch (typeProvaider)
            {
                case ObjectTypeEnumDataProvaider.ALL:
                    return providerSQLite.GetProducts().JoinObjectTypeProductForDifferentProvaider(providerTextXml.GetProducts());
                case ObjectTypeEnumDataProvaider.SQLite:
                    return providerSQLite.GetProducts();
                case ObjectTypeEnumDataProvaider.XML:
                    return providerTextXml.GetProducts();
                default:
                    Console.WriteLine("Default case");
                    return new ObjectTypeProduct[0]; //TODO Exception
            }

        }
    }
   
}
