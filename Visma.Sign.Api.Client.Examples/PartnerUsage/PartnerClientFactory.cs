using Visma.Sign.Api.Client.Settings;
using Visma.Sign.Api.Client.Tokens;

namespace Visma.Sign.Api.Client.Examples.PartnerUsage
{
    public sealed class PartnerClientFactory
    {
        private readonly IEndpoint m_endpoint;
        private readonly ICredentials m_credentials;
        private readonly ICurrentOrganization m_organization;

        public PartnerClientFactory(IEndpoint endpoint, ICredentials credentials, ICurrentOrganization organization)
        {
            m_endpoint = endpoint;
            m_credentials = credentials;
            m_organization = organization;
        }

        public ISignClient Create()
        {
            var response = new ApiResponse(new HttpClientAdapter());
            var partnerToken = new MemoryCachedPartnerAccessToken(
                new PartnerAccessToken(m_credentials, m_endpoint, response, new AllScopes()),
                new CurrentTimeProvider());
            var organizationToken = new MemoryCachedOrganizationToken(new OrganizationToken(m_endpoint, partnerToken, response));

            return new SignClient(
                new PartnerApiRequest(
                    organizationToken,
                    partnerToken,
                    m_endpoint,
                    m_organization),
                response);
        }
    }
}
