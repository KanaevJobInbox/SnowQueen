using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Client.Model;
using SnowQueen.Core.MVVMtools.BaseCommands;
using SnowQueen.Core.ObjectTypes;

namespace Client.ViewModel
{
   public class MainWindowViewModel
    {
        private ProductOperationsViewModel _operations;

        public MainWindowViewModel()
        {
            Product = new ProductViewModel(new ObjectTypeProduct());
            _operations = new ProductOperationsViewModel(new ProductOperationsModel());

            ProductCollection = new ObservableCollection<ProductViewModel>();

            RefreshProductCollection();
        }

        public ProductViewModel Product
        {  get; set; }
        

        public ObservableCollection<ProductViewModel> ProductCollection
        {  get; private set; }



        #region command

        private ObjectTypeEnumDataProvaider converterCommandParameterToEnum(string parameter)
        {
            int intParameter;

            if (!Int32.TryParse(parameter, out intParameter))
            {
                //TODO сделать для данного проекта свои Exception
                throw new ArgumentException("ArgumentException Command Exception");
            }

            switch (intParameter)
            {
                case 3://(int)ObjectTypeEnumDataProvaider.ALL:
                   return ObjectTypeEnumDataProvaider.ALL;
                case 1:
                    return ObjectTypeEnumDataProvaider.SQLite;
                case 2:
                    return ObjectTypeEnumDataProvaider.XML;
                default:
                    //TODO сделать для данного проекта свои Exception
                    throw new ArgumentException("ArgumentException Command Exception");
                     
            }

        }

        #region Command AddProduct

        private DelegateCommand<string> _addProductCommand;
        public ICommand AddProductCommand
        {
            get
            {
                if (_addProductCommand == null)
                { _addProductCommand = new DelegateCommand<string>(this.AddProductCommand_Execute, this.AddProductCommand_CanExecute); }
                return _addProductCommand;
            }
        }

        private void AddProductCommand_Execute(string parameter)
        {
            Product.Id = Guid.NewGuid();
            _operations.AddProduct(new ProductViewModel[] { Product}, converterCommandParameterToEnum(parameter));
        }

        private bool AddProductCommand_CanExecute(string parameter)
        {
            return validateProduct(Product);
        }

        #endregion

        #region Command JoinDataStorage

        private DelegateCommand<string> _joinDataStorageCommand;
        public ICommand JoinDataStorageCommand
        {
            get
            {
                if (_joinDataStorageCommand == null)
                { _joinDataStorageCommand = new DelegateCommand<string>(this.JoinDataStorageCommand_Execute); }
                return _joinDataStorageCommand;
            }
        }

        private void JoinDataStorageCommand_Execute(string parameter)
        {            
            _operations.AddProduct(ProductCollection , converterCommandParameterToEnum(parameter));
        }


        #endregion

        #region Command RefreshProductCollection

        private DelegateCommand _refreshProductCollectionCommand;
        public ICommand RefreshProductCollectionCommand
        {
            get
            {
                if (_refreshProductCollectionCommand == null)
                { _refreshProductCollectionCommand = new DelegateCommand(this.RefreshProductCollectionCommand_Execute); }
                return _refreshProductCollectionCommand;
            }
        }

        private void RefreshProductCollectionCommand_Execute()
        {
            RefreshProductCollection();
        }

        #endregion

       
        #endregion


        //TODO Спорное решение. Будет время, проверку надо менять. Свойства Cost и Count сделать поддерживающими null
        private bool validateProduct(ProductViewModel product)
        {
            return product.Name != null && product.Name != string.Empty &&
                product.Cost > 0 && product.Count > 0;
        }

        private void RefreshProductCollection()
        {
            ProductCollection.Clear();
            
            foreach(var product in _operations.GetProduct(ObjectTypeEnumDataProvaider.ALL))
            {
                ProductCollection.Add(new ProductViewModel(product));
            }
        }

    }
}
