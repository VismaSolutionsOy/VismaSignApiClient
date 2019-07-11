using Visma.Sign.Api.Client.Settings;
using Visma.Sign.Api.Client.Tokens;
using Visma.Sign.Api.Client.UnitTests.Builders.Settings;

namespace Visma.Sign.Api.Client.UnitTests.Builders.Tokens
{
    sealed class OrganizationTokenBuilder
    {
        private IEndpoint m_endpoint = new EndpointStubBuilder().Build();
        private IPartnerAccessToken m_partnerAccessToken = new PartnerAccessTokenStubBuilder().Build();
        private IApiResponse m_response = new ApiResponseStubBuilder<object>().Build();

        public OrganizationTokenBuilder WithEndpoint(IEndpoint value)
        {
            m_endpoint = value;
            return this;
        }

        public OrganizationTokenBuilder WithPartner(IPartnerAccessToken value)
        {
            m_partnerAccessToken = value;
            return this;
        }

        public OrganizationTokenBuilder WithResponse(IApiResponse value)
        {
            m_response = value;
            return this;
        }

        public OrganizationToken Build()
            => new OrganizationToken(m_endpoint, m_partnerAccessToken, m_response);

    }
}
