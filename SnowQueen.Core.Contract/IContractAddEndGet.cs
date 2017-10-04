using System;
using System.Collections.Generic;
using System.ServiceModel;
using SnowQueen.Core.ObjectTypes;

namespace SnowQueen.Core.Contract
{
    [ServiceContract]
    public interface IContractAddEndGet : IContractAdd
    {

        [OperationContract]
        IEnumerable<ObjectTypeProduct> GetProducts(ObjectTypeEnumDataProvaider typeProvaider);
    }
}
