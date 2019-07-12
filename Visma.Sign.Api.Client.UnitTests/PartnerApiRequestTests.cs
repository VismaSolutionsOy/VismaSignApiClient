using System.Net.Http;
using NSubstitute;
using NUnit.Framework;
using Visma.Sign.Api.Client.UnitTests.Builders;
using Visma.Sign.Api.Client.UnitTests.Builders.Dtos;
using Visma.Sign.Api.Client.UnitTests.Builders.Settings;
using Visma.Sign.Api.Client.UnitTests.Builders.Tokens;

namespace Visma.Sign.Api.Client.UnitTests
{
    [TestFixture]
    class PartnerApiRequestTests
    {
        [Test]
        public void Creating_WithPartnerToken_SetsAuthorizationHeaderCorrectly()
        {
            var sut = new PartnerApiRequestBuilder()
                .WithPartner(new PartnerAccessTokenStubBuilder().WithGet(new PartnerAccessTokenDtoBuilder().WithTokenType("Bearer").WithAccessToken("xXx")).Build())
                .Build();

            var actual = sut.Create(new ResourceBaseBuilder()).Result.Headers.Authorization.ToString();

            Assert.AreEqual("Bearer xXx", actual);
        }

        [Test]
        public void Creating_WithoutResourceContainingParameters_SetsUriCorrectly()
        {
            var sut = new PartnerApiRequestBuilder()
                .WithEndpoint(new EndpointStubBuilder().WithUri("https://sign.visma.net/").Build())
                .WithOrganizationToken(new OrganizationTokenStubBuilder().WithGet("1234").Build())
                .Build();

            var actual = sut.Create(new ResourceBaseBuilder().WithResourceUri("api/v1/document")).Result.RequestUri.ToString();

            Assert.AreEqual("https://sign.visma.net/api/v1/document?as_organization=1234", actual);
        }

        [Test]
        public void Creating_WithResourceContainingParameters_SetsUriCorrectly()
        {
            var sut = new PartnerApiRequestBuilder()
                .WithEndpoint(new EndpointStubBuilder().WithUri("https://sign.visma.net/").Build())
                .WithOrganizationToken(new OrganizationTokenStubBuilder().WithGet("5678").Build())
                .Build();

            var actual = sut.Create(new ResourceBaseBuilder().WithResourceUri("api/v1/organization?business_id=1234567-1")).Result.RequestUri.ToString();

            Assert.AreEqual("https://sign.visma.net/api/v1/organization?business_id=1234567-1&as_organization=5678", actual);
        }

        [Test]
        public void Creating_WithGivenBusinessId_GetsCorrectToken()
        {
            var token = new OrganizationTokenStubBuilder().Build();
            var sut = new PartnerApiRequestBuilder()
                .WithCurrentOrganization(new CurrentOrganizationStubBuilder().WithBusinessId("1234567-1").Build())
                .WithOrganizationToken(token)
                .Build();

            sut.Create(new ResourceBaseBuilder()).Wait();

            token.Received(1).Get("1234567-1");
        }

        [Test]
        public void Creating_WithResource_SetsRequestValuesCorrectly()
        {
            var resource = new ResourceBaseBuilder().WithMethod(HttpMethod.Delete).WithRequestBody(new {Value = true});
            var sut = new PartnerApiRequestBuilder().Build();

            var actual = sut.Create(resource).Result;

            Assert.AreEqual(HttpMethod.Delete, actual.Method);
            Assert.AreEqual("{\"Value\":true}", actual.Content.ReadAsStringAsync().Result);
        }
    }
}
