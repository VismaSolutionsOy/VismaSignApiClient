using System.Threading.Tasks;

namespace Visma.Sign.Api.Client.Tokens
{
    public interface IOrganizationToken
    {
        Task<string> Get(string businessId);
    }
}
