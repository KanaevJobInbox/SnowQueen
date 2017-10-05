using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Model;
using SnowQueen.Core.ObjectTypes;
using Client.ViewModel.Extension;

namespace Client.ViewModel
{
    class ProductOperationsViewModel
    {

        private ProductOperationsModel operations;
        public ProductOperationsViewModel(ProductOperationsModel Operations)
        {
            operations = Operations;
        }

        public void AddProduct(IEnumerable<ProductViewModel> product, ObjectTypeEnumDataProvaider typeProvaider)
        {
            operations.AddProducts(product.ConvertToCollectionObjectTypeProduct(), typeProvaider);
        }

        public IEnumerable<IProduct> GetProduct(ObjectTypeEnumDataProvaider typeProvaider)
        {
            return operations.GetProducts(typeProvaider);
        }

    }
}
