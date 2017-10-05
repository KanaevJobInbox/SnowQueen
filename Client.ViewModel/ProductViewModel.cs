using System;
using Client.Model;
using SnowQueen.Core.MVVMtools;
using SnowQueen.Core.ObjectTypes;

namespace Client.ViewModel
{
    public class ProductViewModel : BaseViewModel, IProduct
    {

        private ObjectTypeProduct _product;

        public ProductViewModel(IProduct product)
        {
            _product = new ObjectTypeProduct(product);
        }


        public Guid Id
        {
            get { return _product.Id; }
            set { _product.Id = value; }
        }

        public string Name
        {
            get { return _product.Name; }
            set { _product.Name = value; OnPropertyChanged("Name"); }
        }
        public int Cost
        {
            get { return _product.Cost; }
            set { _product.Cost = value; OnPropertyChanged("Cost"); }
        }
        public int Count
        {
            get { return _product.Count; }
            set { _product.Count = value; OnPropertyChanged("Count"); }
        }

        public ObjectTypeEnumDataProvaider TypeProvaider
        {
            get { return _product.TypeProvaider; }
            set { _product.TypeProvaider = value; OnPropertyChanged("TypeProvaider"); }
        }

        public ObjectTypeProduct ConvertToObjectType()
        {
            return _product;
        }

    }
}
