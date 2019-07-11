using NSubstitute;
using Visma.Sign.Api.Client.Dtos;
using Visma.Sign.Api.Client.Tokens;
using Visma.Sign.Api.Client.UnitTests.Builders.Dtos;

namespace Visma.Sign.Api.Client.UnitTests.Builders.Tokens
{
    sealed class PartnerAccessTokenStubBuilder
    {
        private PartnerAccessTokenDto m_get = new PartnerAccessTokenDtoBuilder();

        public PartnerAccessTokenStubBuilder WithGet(PartnerAccessTokenDto value)
        {
            m_get = value;
            return this;
        }

        public IPartnerAccessToken Build()
        {
            var stub = Substitute.For<IPartnerAccessToken>();
            stub.Get().Returns(m_get);

            return stub;
        }
    }
}
