using System;
using System.Threading.Tasks;
using Visma.Sign.Api.Client.Dtos;

namespace Visma.Sign.Api.Client.Tokens
{
    public sealed class MemoryCachedPartnerAccessToken : IPartnerAccessToken
    {
        private readonly IPartnerAccessToken m_decorated;
        private readonly ITimeProvider m_time;
        private PartnerAccessTokenDto m_partnerAccess;
        private DateTime? m_expiryTime;

        public MemoryCachedPartnerAccessToken(IPartnerAccessToken decorated, ITimeProvider time)
        {
            m_decorated = decorated;
            m_time = time;
        }

        public async Task<PartnerAccessTokenDto> Get()
        {
            if (m_partnerAccess == null || HasExpired())
            {
                var access = await m_decorated.Get();
                m_partnerAccess = access;
                m_expiryTime = m_time.UtcNow().AddSeconds(access.expires_in);
            }

            return m_partnerAccess;
        }

        private bool HasExpired() 
            => m_expiryTime.HasValue && m_expiryTime.Value <= m_time.UtcNow();
    }
}
