using System.Collections.Generic;
using System.Threading.Tasks;

namespace Visma.Sign.Api.Client.Tokens
{
    public sealed class MemoryCachedOrganizationToken : IOrganizationToken
    {
        private readonly IOrganizationToken m_decorated;
        private readonly Dictionary<string, string> m_organizationMappings;

        public MemoryCachedOrganizationToken(IOrganizationToken decorated)
        {
            m_decorated = decorated;
            m_organizationMappings = new Dictionary<string, string>();
        }

        public async Task<string> Get(string organizationIdentifier)
        {
            if (!m_organizationMappings.ContainsKey(organizationIdentifier))
            {
                m_organizationMappings.Add(organizationIdentifier, await m_decorated.Get(organizationIdentifier));
            }

            return m_organizationMappings[organizationIdentifier];
        }
    }
}
