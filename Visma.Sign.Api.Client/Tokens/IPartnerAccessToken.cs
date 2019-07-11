using System.Threading.Tasks;
using Visma.Sign.Api.Client.Dtos;

namespace Visma.Sign.Api.Client.Tokens
{
    public interface IPartnerAccessToken
    {
        Task<PartnerAccessTokenDto> Get();
    }
}
