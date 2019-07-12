using Visma.Sign.Api.Client.Settings;

namespace Visma.Sign.Api.Client.Examples
{
    public sealed class HardcodedOrganization : ICurrentOrganization
    {
        private readonly string m_identifier;

        public HardcodedOrganization(string identifier)
        {
            m_identifier = identifier;
        }

        public string BusinessId()
            => m_identifier;
    }
}
