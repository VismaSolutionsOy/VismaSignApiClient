using NSubstitute;
using NUnit.Framework;
using Visma.Sign.Api.Client.UnitTests.Builders.Tokens;

namespace Visma.Sign.Api.Client.UnitTests.Tokens
{
    [TestFixture]
    class MemoryCachedOrganizationTokenTests
    {
        [Test]
        public void AskingOrganization_WithFirstTime_GetsItFromDecorated()
        {
            var decorated = new OrganizationTokenStubBuilder().WithGet("xxx").Build();
            var sut = new MemoryCachedOrganizationTokenBuilder()
                .WithOrganization(decorated)
                .Build();

            var actual = sut.Get("6136813-2").Result;

            Assert.AreEqual("xxx", actual);
            decorated.Received(1).Get("6136813-2");
        }

        [Test]
        public void AskingOrganization_WithMultipleTimes_GetsItOnlyOnceFromDecorated()
        {
            var decorated = new OrganizationTokenStubBuilder().WithGet("xxx").Build();
            var sut = new MemoryCachedOrganizationTokenBuilder()
                .WithOrganization(decorated)
                .Build();

            _ = sut.Get("6136813-2").Result;
            _ = sut.Get("6136813-2").Result;
            var actual = sut.Get("6136813-2").Result;

            Assert.AreEqual("xxx", actual);
            decorated.Received(1).Get("6136813-2");
        }

        [Test]
        public void AskingOrganization_WithDifferentIdentifiers_LoadsThemCorrectly()
        {
            var sut = new MemoryCachedOrganizationTokenBuilder()
                .WithOrganization(new OrganizationTokenStubBuilder().WithGetInOrder("xxx", "yyy").Build())
                .Build();

            var first = sut.Get("123456-7").Result;
            var second = sut.Get("765432-1").Result;

            Assert.AreEqual("xxx", first);
            Assert.AreEqual("yyy", second);
        }

        [Test]
        public void AskingOrganization_WithDifferentIdentifiers_CallsDecoratedCorrectly()
        {
            var decorated = new OrganizationTokenStubBuilder().WithGetInOrder("xxx", "yyy").Build();
            var sut = new MemoryCachedOrganizationTokenBuilder()
                .WithOrganization(decorated)
                .Build();

            sut.Get("123456-7").Wait();
            sut.Get("765432-1").Wait();

            Received.InOrder(() =>
            {
                decorated.Get("123456-7");
                decorated.Get("765432-1");
            });
        }

    }
}
