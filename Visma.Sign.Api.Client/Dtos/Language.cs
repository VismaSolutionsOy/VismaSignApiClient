using System.Runtime.Serialization;

namespace Visma.Sign.Api.Client.Dtos
{
    public enum Language
    {
        [EnumMember(Value =  "fi")]
        Finnish,
        [EnumMember(Value =  "en")]
        English,
        [EnumMember(Value =  "sv")]
        Swedish,
        [EnumMember(Value = "nb")]
        Norwegian,
        [EnumMember(Value = "da")]
        Danish
    }
}
