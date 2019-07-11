using Visma.Sign.Api.Client.Resources.V1;
using Visma.Sign.Api.Client.Settings;
using Visma.Sign.Api.Client.UnitTests.Builders.Settings;

namespace Visma.Sign.Api.Client.UnitTests.Builders.Resources.V1
{
    sealed class RequestAuthorizationBuilder
    {
        private ICredentials m_credentials = new CredentialsStubBuilder().Build();
        private IScopes m_scopes = new ScopesStubBuilder().Build();

        public RequestAuthorizationBuilder WithCredentials(ICredentials value)
        {
            m_credentials = value;
            return this;
        }

        public RequestAuthorizationBuilder WithScopes(IScopes value)
        {
            m_scopes = value;
            return this;
        }

        public RequestAuthorization Build()
            => new RequestAuthorization(m_credentials, m_scopes);

    }
}
