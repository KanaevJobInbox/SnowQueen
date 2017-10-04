using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnowQueen.Core.ObjectTypes;
using SnowQueen.Core.ObjectTypes.Extension;

namespace SnowQueen.Server.DataProvider.SQLite
{
    class SQLiteDataProvider
    {

        public void AddProducts(IEnumerable<ObjectTypeProduct> products)
        {
            var context = new SnowQueenDBContext();

            foreach (var product in products)
            {
                var efProduct = new Product()
                {
                    Id = product.Id.ToByteArray(),
                    Name = product.Name,
                    Cost = product.Cost,
                    Count = product.Count
                };

                //if (context.Product.Find(efProduct) == null
                if (!context.Product.ToList().Any(o=> o.Id == efProduct.Id))
                    context.Product.Add(efProduct);
            }

            context.SaveChanges();
        }

        public IEnumerable<ObjectTypeProduct> GetProducts()
        {
            var context = new SnowQueenDBContext();

            foreach (var product in context.Product)
            {
                yield return new ObjectTypeProduct()
                {
                    Id = new Guid(product.Id),
                    Name = product.Name,
                    Cost = product.Cost,
                    Count = product.Count,
                    TypeProvaider  = ObjectTypeEnumDataProvaider.SQLite
                };
            }

        }
    }
}
