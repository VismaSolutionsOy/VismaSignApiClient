using Visma.Sign.Api.Client.Settings;
using Visma.Sign.Api.Client.Tokens;
using Visma.Sign.Api.Client.UnitTests.Builders.Settings;
using Visma.Sign.Api.Client.UnitTests.Builders.Tokens;

namespace Visma.Sign.Api.Client.UnitTests.Builders
{
    class PartnerApiRequestBuilder
    {
        private IOrganizationToken m_organizationToken = new OrganizationTokenStubBuilder().Build();
        private IPartnerAccessToken m_partnerAccessToken = new PartnerAccessTokenStubBuilder().Build();
        private IEndpoint m_endpoint = new EndpointStubBuilder().Build();
        private ICurrentOrganization m_organization = new CurrentOrganizationStubBuilder().Build();

        public PartnerApiRequestBuilder WithOrganizationToken(IOrganizationToken value)
        {
            m_organizationToken = value;
            return this;
        }

        public PartnerApiRequestBuilder WithPartner(IPartnerAccessToken value)
        {
            m_partnerAccessToken = value;
            return this;
        }

        public PartnerApiRequestBuilder WithEndpoint(IEndpoint value)
        {
            m_endpoint = value;
            return this;
        }

        public PartnerApiRequestBuilder WithCurrentOrganization(ICurrentOrganization value)
        {
            m_organization = value;
            return this;
        }

        public PartnerApiRequest Build()
            => new PartnerApiRequest(m_organizationToken, m_partnerAccessToken, m_endpoint, m_organization);
    }
}
