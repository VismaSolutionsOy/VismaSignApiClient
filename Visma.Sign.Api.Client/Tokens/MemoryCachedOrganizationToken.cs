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

        public async Task<string> Get(string businessId)
        {
            if (!m_organizationMappings.ContainsKey(businessId))
            {
                m_organizationMappings.Add(businessId, await m_decorated.Get(businessId));
            }

            return m_organizationMappings[businessId];
        }
    }
}
