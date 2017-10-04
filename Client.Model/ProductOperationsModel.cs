using System;
using System.Collections.Generic;
using System.ServiceModel;
using SnowQueen.Core.Contract;
using SnowQueen.Core.ObjectTypes;

namespace Client.Model
{
   public class ProductOperationsModel : IContractAddEndGet
    {

        public void AddProducts(IEnumerable<ObjectTypeProduct> products, ObjectTypeEnumDataProvaider typeProvaider)
        {
            var channel = GetChannel();

            channel.AddProducts(products, typeProvaider);
        }

        public IEnumerable<ObjectTypeProduct> GetProducts(ObjectTypeEnumDataProvaider typeProvaider)
        {
            var channel = GetChannel();

           return channel.GetProducts(typeProvaider);
        }

        private IContractAddEndGet GetChannel()
        {
            Uri address = new Uri("http://localhost:4001/IContractAddEndGet");
            BasicHttpBinding binding = new BasicHttpBinding();
            EndpointAddress endpoint = new EndpointAddress(address);

            ChannelFactory<IContractAddEndGet> factory = new ChannelFactory<IContractAddEndGet>(binding, endpoint);

            return factory.CreateChannel();

        }
       
    }
}
