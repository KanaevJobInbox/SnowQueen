using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnowQueen.Core.ObjectTypes;

namespace Client.ViewModel.Extension
{
    public static class ProductViewModelExtension
    {
        public static IEnumerable<ObjectTypeProduct> ConvertToCollectionObjectTypeProduct(this IEnumerable<ProductViewModel> products)
        {
            foreach (var product in products)
                yield return product.ConvertToObjectType();
        }
    }
}
