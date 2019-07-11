using Visma.Sign.Api.Client.Dtos;

namespace Visma.Sign.Api.Client.UnitTests.Builders.Dtos
{
    sealed class PartnerAccessTokenDtoBuilder
    {
        private string m_accessToken = "xxxx";
        private int m_expiresIn = 1;
        private string m_tokenType = "Bearer";
        private string m_scope = "";

        public PartnerAccessTokenDtoBuilder WithAccessToken(string value)
        {
            m_accessToken = value;
            return this;
        }

        public PartnerAccessTokenDtoBuilder WithExpiresIn(int value)
        {
            m_expiresIn = value;
            return this;
        }

        public PartnerAccessTokenDtoBuilder WithTokenType(string value)
        {
            m_tokenType = value;
            return this;
        }

        public PartnerAccessTokenDtoBuilder WithScope(string value)
        {
            m_scope = value;
            return this;
        }

        public PartnerAccessTokenDto Build()
            => new PartnerAccessTokenDto()
            {
                access_token = m_accessToken,
                expires_in = m_expiresIn,
                scope = m_scope,
                token_type = m_tokenType
            };

        public static implicit operator PartnerAccessTokenDto(PartnerAccessTokenDtoBuilder b)
            => b.Build();
    }
}
