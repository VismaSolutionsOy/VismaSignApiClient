using NSubstitute;
using Visma.Sign.Api.Client.Settings;

namespace Visma.Sign.Api.Client.UnitTests.Builders.Settings
{
    sealed class CredentialsStubBuilder
    {
        private string m_identifier = "";
        private string m_secret = "";

        public CredentialsStubBuilder WithIdentifier(string value)
        {
            m_identifier = value;
            return this;
        }

        public CredentialsStubBuilder WithSecret(string value)
        {
            m_secret = value;
            return this;
        }

        public ICredentials Build()
        {
            var stub = Substitute.For<ICredentials>();
            stub.Identifier().Returns(m_identifier);
            stub.Secret().Returns(m_secret);

            return stub;
        }
    }
}
