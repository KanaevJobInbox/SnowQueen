using System;
using System.Collections.Generic;
using System.ServiceModel;
using SnowQueen.Core.ObjectTypes;


namespace SnowQueen.Core.Contract
{
    [ServiceContract]
    public interface IContractAdd
    {
        [OperationContract]
        void AddProducts(IEnumerable<ObjectTypeProduct> products, ObjectTypeEnumDataProvaider typeProvaider);
    }
}
