using System;
using System.Net.Http;
using System.Threading.Tasks;
using Visma.Sign.Api.Client.Settings;
using Visma.Sign.Api.Client.Tokens;

namespace Visma.Sign.Api.Client
{
    public sealed class PartnerApiRequest : IApiRequest
    {
        private readonly IOrganizationToken m_organizationToken;
        private readonly IPartnerAccessToken m_partnerAccessToken;
        private readonly IEndpoint m_endpoint;
        private readonly ICurrentOrganization m_organization;

        public PartnerApiRequest(
            IOrganizationToken organizationToken,
            IPartnerAccessToken partnerAccessToken,
            IEndpoint endpoint,
            ICurrentOrganization organization)
        {
            m_organizationToken = organizationToken;
            m_partnerAccessToken = partnerAccessToken;
            m_endpoint = endpoint;
            m_organization = organization;
        }

        public async Task<HttpRequestMessage> Create(ResourceBase value)
        {
            var request = new HttpRequestMessage(value.Method, await RequestUri(value));
            request.Content = value.Content;
            request.Headers.Add("Authorization", (await m_partnerAccessToken.Get()).PartnerToken());

            return request;
        }

        private async Task<Uri> RequestUri<TRequest>(TRequest value) where TRequest : ResourceBase
        {
            var requestBaseUri = new Uri(m_endpoint.Uri() + value.ResourceUri);
            var parameterSeparator = string.IsNullOrEmpty(requestBaseUri.Query) ? "?" : "&";
            
            return new Uri(m_endpoint.Uri() + value.ResourceUri + parameterSeparator + "as_organization=" + await m_organizationToken.Get(m_organization.OrganizationIdentifier()));
        } 
    }
}
