using System.Runtime.Serialization;

namespace Visma.Sign.Api.Client.Dtos
{
    public enum SignatureType
    {
        [EnumMember(Value = "strong")]
        Strong,
        [EnumMember(Value =  "hand")]
        Hand
    }
}
