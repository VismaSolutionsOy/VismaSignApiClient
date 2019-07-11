using System;
using System.Net.Http;
using System.Threading.Tasks;
using Visma.Sign.Api.Client.Dtos;
using Visma.Sign.Api.Client.Resources;
using Visma.Sign.Api.Client.Resources.V1;
using Visma.Sign.Api.Client.Settings;

namespace Visma.Sign.Api.Client.Tokens
{
    public sealed class PartnerPartnerAccessToken : IPartnerAccessToken
    {
        private readonly ICredentials m_credentials;
        private readonly IEndpoint m_endpoint;
        private readonly IApiResponse m_response;
        private readonly IScopes m_scopes;

        public PartnerPartnerAccessToken(ICredentials credentials, IEndpoint endpoint, IApiResponse response, IScopes scopes)
        {
            m_credentials = credentials;
            m_endpoint = endpoint;
            m_response = response;
            m_scopes = scopes;
        }


        public async Task<PartnerAccessTokenDto> Get()
        {
            var uri = new Uri(m_endpoint.Uri() + "api/v1/auth/token");
            var request = new HttpRequestMessage(HttpMethod.Post, uri)
            {
                Content = new RequestAuthorization(m_credentials, m_scopes).Content
            };

            return await m_response.GetResponse<PartnerAccessTokenDto>(request);
        }
    }
}
