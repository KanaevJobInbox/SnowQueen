using System.Runtime.Serialization;

namespace SnowQueen.Core.ObjectTypes
{
    [DataContract]
    public enum ObjectTypeEnumDataProvaider
    {

        //[EnumMemberAttribute]
        [EnumMember]
        SQLite,
        [EnumMember]
        XML,
        [EnumMember]
        ALL = 3
    }
}
