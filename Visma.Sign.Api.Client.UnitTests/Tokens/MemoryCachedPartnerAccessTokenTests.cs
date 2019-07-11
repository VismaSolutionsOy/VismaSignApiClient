using System;
using NSubstitute;
using NUnit.Framework;
using Visma.Sign.Api.Client.Dtos;
using Visma.Sign.Api.Client.UnitTests.Builders;
using Visma.Sign.Api.Client.UnitTests.Builders.Dtos;
using Visma.Sign.Api.Client.UnitTests.Builders.Tokens;

namespace Visma.Sign.Api.Client.UnitTests.Tokens
{
    [TestFixture]
    class MemoryCachedPartnerAccessTokenTests
    {
        [Test]
        public void AskingPartner_WithoutPartnerLoaded_GetsIt()
        {
            var expectedToken = new PartnerAccessTokenDtoBuilder().Build();
            var decorated = new PartnerAccessTokenStubBuilder().WithGet(expectedToken).Build();
            var sut = new MemoryCachedPartnerAccessTokenBuilder().WithPartner(decorated).Build();

            var actualToken = sut.Get().Result;

            Assert.AreEqual(expectedToken, actualToken);
            decorated.Received(1).Get();
        }

        [Test]
        public void AskingPartner_WithPartnerBeingLoaded_GetsItOnce()
        {
            var expectedToken = new PartnerAccessTokenDtoBuilder().WithExpiresIn(60).Build();
            var decorated = new PartnerAccessTokenStubBuilder().WithGet(expectedToken).Build();
            var sut = new MemoryCachedPartnerAccessTokenBuilder().WithPartner(decorated).Build();

            _ = sut.Get().Result;
            _ = sut.Get().Result;
            var actualToken = sut.Get().Result;
            
            Assert.AreEqual(expectedToken, actualToken);
            decorated.Received(1).Get();
        }

        [Test]
        public void AskingPartner_WithPartnerDtoExpired_GetsItAgain()
        {
            var decorated = new PartnerAccessTokenStubBuilder().WithGet(new PartnerAccessTokenDtoBuilder().WithExpiresIn(60)).Build();
            var sut = new MemoryCachedPartnerAccessTokenBuilder()
                .WithPartner(decorated)
                .WithTime(new TimeProviderStubBuilder()
                    .WithUtcNowInOrder(new DateTime(2000, 1, 1, 0, 0, 0))
                    .WithUtcNowInOrder(new DateTime(2000, 1, 1, 0, 1, 0))
                    .Build())
                .Build();

            sut.Get().Wait();
            sut.Get().Wait();

            decorated.Received(2).Get();
        }
    }
}
