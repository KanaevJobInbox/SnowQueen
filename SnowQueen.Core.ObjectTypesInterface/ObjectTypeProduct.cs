using System;
using System.Runtime.Serialization;

namespace SnowQueen.Core.ObjectTypes
{
    [DataContract]
   public class ObjectTypeProduct : IProduct
    {
        public ObjectTypeProduct()
        { Id = Guid.NewGuid(); }

        public ObjectTypeProduct(IProduct product)
        {
            Id = Guid.NewGuid();
            Name = product.Name;
            Cost = product.Cost;
            Count = product.Count;
            TypeProvaider = product.TypeProvaider;
        }


        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Cost { get; set; }
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public ObjectTypeEnumDataProvaider TypeProvaider { get; set; }
    }
}
