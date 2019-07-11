using System.Net.Http;
using System.Threading.Tasks;

namespace Visma.Sign.Api.Client
{
    public sealed class HttpClientAdapter : IHttpClient
    {
        private readonly HttpClient m_client;

        public HttpClientAdapter()
        {
            m_client = new HttpClient();
        }

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
            => m_client.SendAsync(request);
    }
}
