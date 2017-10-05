using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowQueen.Core.ObjectTypes
{
    public interface IProduct
    {
        Guid Id { get; }
        string Name { get; }
        int Cost { get; }
        int Count { get; }
        ObjectTypeEnumDataProvaider TypeProvaider { get; }
    }
}
