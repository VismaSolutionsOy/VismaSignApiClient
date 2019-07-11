using System.Net.Http;
using System.Threading.Tasks;

namespace Visma.Sign.Api.Client
{
    public interface IApiRequest
    {
        Task<HttpRequestMessage> Create(ResourceBase resource);
    }
}
