using Visma.Sign.Api.Client.Settings;
using Visma.Sign.Api.Client.UnitTests.Builders.Settings;

namespace Visma.Sign.Api.Client.UnitTests.Builders
{
    sealed class OrganizationApiRequestBuilder
    {
        private ICredentials m_credentials = new CredentialsStubBuilder().Build(); 
        private IEndpoint m_endpoint = new EndpointStubBuilder().Build();
        private ITimeProvider m_time = new TimeProviderStubBuilder().Build();

        public OrganizationApiRequestBuilder WithCredentials(ICredentials value)
        {
            m_credentials = value;
            return this;
        }

        public OrganizationApiRequestBuilder WithEndpoint(IEndpoint value)
        {
            m_endpoint = value;
            return this;
        }

        public OrganizationApiRequestBuilder WithTime(ITimeProvider value)
        {
            m_time = value;
            return this;
        }

        public OrganizationApiRequest Build()
            => new OrganizationApiRequest(m_credentials, m_endpoint, m_time);

    }
}
