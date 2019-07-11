using Visma.Sign.Api.Client.Tokens;

namespace Visma.Sign.Api.Client.UnitTests.Builders.Tokens
{
    sealed class MemoryCachedPartnerAccessTokenBuilder
    {
        private IPartnerAccessToken m_partner = new PartnerAccessTokenStubBuilder().Build();
        private ITimeProvider m_time = new TimeProviderStubBuilder().Build();

        public MemoryCachedPartnerAccessTokenBuilder WithPartner(IPartnerAccessToken value)
        {
            m_partner = value;
            return this;
        }

        public MemoryCachedPartnerAccessTokenBuilder WithTime(ITimeProvider value)
        {
            m_time = value;
            return this;
        }

        public MemoryCachedPartnerAccessToken Build()
            => new MemoryCachedPartnerAccessToken(m_partner, m_time);
    }
}
