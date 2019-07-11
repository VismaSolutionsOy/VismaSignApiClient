using System.Threading.Tasks;

namespace Visma.Sign.Api.Client
{
    public sealed class SignClient : ISignClient
    {
        private readonly IApiRequest m_request;
        private readonly IApiResponse m_response;

        public SignClient(IApiRequest request, IApiResponse response)
        {
            m_request = request;
            m_response = response;
        }

        public async Task<TResult> SendRequest<TResult>(ResourceBase resource)
            where TResult : class
        {
            var response = await m_request.Create(resource);
            return await m_response.GetResponse<TResult>(response);
        }
    }
}
