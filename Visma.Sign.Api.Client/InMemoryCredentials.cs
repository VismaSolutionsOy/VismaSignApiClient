using Visma.Sign.Api.Client.Settings;

namespace Visma.Sign.Api.Client
{
    public sealed class InMemoryCredentials : ICredentials
    {
        private readonly string m_secret;
        private readonly string m_identifier;

        public InMemoryCredentials(string identifier, string secret)
        {
            m_secret = secret;
            m_identifier = identifier;
        }

        public string Secret()
            => m_secret;

        public string Identifier()
            => m_identifier;
    }
}
