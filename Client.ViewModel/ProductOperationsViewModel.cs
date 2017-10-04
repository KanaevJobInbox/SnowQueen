using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Model;
using SnowQueen.Core.ObjectTypes;

namespace Client.ViewModel
{
    class ProductOperationsViewModel
    {

        private ProductOperationsModel operations;
        public ProductOperationsViewModel(ProductOperationsModel Operations)
        {
            operations = Operations;
        }

        public void AddProduct(IEnumerable<IProduct> product, ObjectTypeEnumDataProvaider typeProvaider)
        {
            List<ObjectTypeProduct> otProduct = new List<ObjectTypeProduct>();
            foreach (var item in product)
            {
                otProduct.Add(new ObjectTypeProduct(item));
            }

            operations.AddProducts(otProduct, typeProvaider);
        }

        public IEnumerable<IProduct> GetProduct(ObjectTypeEnumDataProvaider typeProvaider)
        {
            return operations.GetProducts(typeProvaider);
        }

    }
}
