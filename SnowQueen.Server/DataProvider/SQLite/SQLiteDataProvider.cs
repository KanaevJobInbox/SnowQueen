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

            var currentProduct = context.Product.ToList();

            foreach (var product in products)
            {
                var productId = product.Id.ToByteArray();

                if (!currentProduct.Any(o=> DeepEqualArray(o.Id, productId)))
                    context.Product.Add(new Product()
                                   {
                                       Id = productId,
                                       Name = product.Name,
                                       Cost = product.Cost,
                                       Count = product.Count
                                   }
                            );
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

        private bool DeepEqualArray<T>(IEnumerable<T> array1, IEnumerable<T> array2)
        {
          return  array1.All(t => array2.Contains(t));
        }
    }
}
