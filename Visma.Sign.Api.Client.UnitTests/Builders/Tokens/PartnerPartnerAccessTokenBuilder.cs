using Visma.Sign.Api.Client.Settings;
using Visma.Sign.Api.Client.Tokens;
using Visma.Sign.Api.Client.UnitTests.Builders.Settings;

namespace Visma.Sign.Api.Client.UnitTests.Builders.Tokens
{
    sealed class PartnerAccessTokenBuilder
    {
        private ICredentials m_credentials = new CredentialsStubBuilder().Build();
        private IEndpoint m_endpoint = new EndpointStubBuilder().Build();
        private IApiResponse m_response = new ApiResponseStubBuilder<object>().Build();
        private IScopes m_scopes = new ScopesStubBuilder().Build();

        public PartnerAccessTokenBuilder WithCredentials(ICredentials value)
        {
            m_credentials = value;
            return this;
        }

        public PartnerAccessTokenBuilder WithEndpoint(IEndpoint value)
        {
            m_endpoint = value;
            return this;
        }

        public PartnerAccessTokenBuilder WithResponse(IApiResponse value)
        {
            m_response = value;
            return this;
        }

        public PartnerAccessTokenBuilder WithScopes(IScopes value)
        {
            m_scopes = value;
            return this;
        }

        public PartnerAccessToken Build()
            => new PartnerAccessToken(m_credentials, m_endpoint, m_response, m_scopes);

    }
}
