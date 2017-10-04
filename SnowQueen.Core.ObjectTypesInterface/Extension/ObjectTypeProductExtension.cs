using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowQueen.Core.ObjectTypes.Extension
{
    public static class ObjectTypeProductExtension
    {

        public static IEnumerable<ObjectTypeProduct> JoinObjectTypeProduct(this IEnumerable<ObjectTypeProduct> CurrentProduts, IEnumerable<ObjectTypeProduct> NewProducts)
        {
            var result = CurrentProduts.ToList();

            foreach (var newProduct in NewProducts)
            {
                if (!result.Any(curr => curr.Id == newProduct.Id))
                {
                    result.Add(newProduct);
                }
            }
            return result;
        }


        public static IEnumerable<ObjectTypeProduct> JoinObjectTypeProductForDifferentProvaider(this IEnumerable<ObjectTypeProduct> CurrentProduts, IEnumerable<ObjectTypeProduct> NewProducts)
        {
            var result = CurrentProduts.ToList();

            foreach (var newProduct in NewProducts)
            {
                var findProduct = result.FirstOrDefault(curr => curr.Id == newProduct.Id);
                if (findProduct == null)
                {
                    result.Add(newProduct);
                }
                else
                {
                    findProduct.TypeProvaider = ObjectTypeEnumDataProvaider.ALL;
                }
            }
            return result;
        }

    }
}
