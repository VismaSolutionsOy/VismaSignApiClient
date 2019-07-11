using Visma.Sign.Api.Client.Settings;

namespace Visma.Sign.Api.Client.Examples
{
    public sealed class HardcodedCredentials : ICredentials
    {
        private readonly string m_secret;
        private readonly string m_identifier;

        public HardcodedCredentials(string secret, string identifier)
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
