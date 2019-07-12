using System.Net.Http;
using NUnit.Framework;
using Visma.Sign.Api.Client.Dtos;
using Visma.Sign.Api.Client.UnitTests.Builders.Resources.V1;

namespace Visma.Sign.Api.Client.UnitTests.Resources.V1
{
    [TestFixture]
    class RequestAccessToOrganizationTests
    {
        [Test]
        public void RequestingAccess_WithGivenValues_SetsUriCorrectly()
        {
            var sut = new RequestAccessToOrganizationBuilder()
                .WithOrganizationUuid("1234-4567")
                .WithLanguage(Language.Danish)
                .Build();

            var actual = sut.ResourceUri;

            Assert.AreEqual("api/v1/organization/1234-4567/client-authorization?lang=da", actual);
        }

        [Test]
        public void RequestingAccess_WithGivenMessage_SetsContentCorrectly()
        {
            var sut = new RequestAccessToOrganizationBuilder().WithMessage("Example").Build();

            var actual = sut.Content.ReadAsStringAsync().Result;

            Assert.AreEqual("{\"message\":\"Example\"}", actual);
        }

        [Test]
        public void RequestingAccess_WithHttpMethod_IsExpected()
        {
            var sut = new RequestAccessToOrganizationBuilder().Build();

            var actual = sut.Method;

            Assert.AreEqual(HttpMethod.Post, actual);
        }

    }
}
