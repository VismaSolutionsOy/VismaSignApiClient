using Visma.Sign.Api.Client.Settings;

namespace Visma.Sign.Api.Client
{
    public sealed class InMemoryOrganization : ICurrentOrganization
    {
        private readonly string m_businessId;

        public InMemoryOrganization(string businessId)
        {
            m_businessId = businessId;
        }

        public string BusinessId()
            => m_businessId;
    }
}
