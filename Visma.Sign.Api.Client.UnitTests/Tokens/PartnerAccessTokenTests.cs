using System.Net.Http;
using NSubstitute;
using NUnit.Framework;
using Visma.Sign.Api.Client.Dtos;
using Visma.Sign.Api.Client.UnitTests.Builders;
using Visma.Sign.Api.Client.UnitTests.Builders.Dtos;
using Visma.Sign.Api.Client.UnitTests.Builders.Settings;
using Visma.Sign.Api.Client.UnitTests.Builders.Tokens;

namespace Visma.Sign.Api.Client.UnitTests.Tokens
{
    [TestFixture]
    class PartnerAccessTokenTests
    {
        [Test]
        public void AskingToken_WithEndpoint_SendsRequestCorrectly()
        {
            var response = new ApiResponseStubBuilder<PartnerAccessTokenDto>().Build();
            var sut = new PartnerAccessTokenBuilder()
                .WithEndpoint(new EndpointStubBuilder().WithUri("https://sign.visma.net/").Build())
                .WithResponse(response)
                .Build();

            sut.Get().Wait();

            response.Received(1).GetResponse<PartnerAccessTokenDto>(Arg.Is<HttpRequestMessage>(value =>
                "https://sign.visma.net/api/v1/auth/token".Equals(value.RequestUri.ToString())));
        }

        [Test]
        public void AskingToken_WithCredentialsAndScopes_SendsRequestCorrectly()
        {
            var response = new ApiResponseStubBuilder<PartnerAccessTokenDto>().Build();
            var sut = new PartnerAccessTokenBuilder()
                .WithScopes(new ScopesStubBuilder().WithRequired("document_create").Build())
                .WithCredentials(new CredentialsStubBuilder().WithSecret("secret").WithIdentifier("identifier").Build())
                .WithResponse(response)
                .Build();

            sut.Get().Wait();

            response.Received(1).GetResponse<PartnerAccessTokenDto>(Arg.Is<HttpRequestMessage>(value =>
                value.Content.ReadAsStringAsync().Result.Contains("grant_type=client_credentials") &&
                value.Content.ReadAsStringAsync().Result.Contains("&client_id=identifier") &&
                value.Content.ReadAsStringAsync().Result.Contains("&client_secret=secret") &&
                value.Content.ReadAsStringAsync().Result.Contains("&scope=document_create")));
        }

        [Test]
        public void AskingToken_WithFindingToken_ReturnsExpected()
        {
            var expected = new PartnerAccessTokenDtoBuilder().Build();
            var sut = new PartnerAccessTokenBuilder()
                .WithResponse(new ApiResponseStubBuilder<PartnerAccessTokenDto>().WithGetResponse(expected).Build())
                .Build();

            var actual = sut.Get().Result;

            Assert.AreEqual(expected, actual);
        }
    }
}
