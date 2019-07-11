using System.Net.Http;
using System.Threading.Tasks;

namespace Visma.Sign.Api.Client
{
    public interface IHttpClient
    {
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
    }
}
