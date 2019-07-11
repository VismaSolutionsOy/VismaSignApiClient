using Visma.Sign.Api.Client.Tokens;

namespace Visma.Sign.Api.Client.UnitTests.Builders.Tokens
{
    sealed class MemoryCachedOrganizationTokenBuilder
    {
        private IOrganizationToken m_organization = new OrganizationTokenStubBuilder().Build();

        public MemoryCachedOrganizationTokenBuilder WithOrganization(IOrganizationToken value)
        {
            m_organization = value;
            return this;
        }

        public MemoryCachedOrganizationToken Build()
            => new MemoryCachedOrganizationToken(m_organization);
    }
}
