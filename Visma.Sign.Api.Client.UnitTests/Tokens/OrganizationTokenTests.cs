using System.Net.Http;
using NSubstitute;
using NUnit.Framework;
using Visma.Sign.Api.Client.Dtos;
using Visma.Sign.Api.Client.Tokens;
using Visma.Sign.Api.Client.UnitTests.Builders;
using Visma.Sign.Api.Client.UnitTests.Builders.Dtos;
using Visma.Sign.Api.Client.UnitTests.Builders.Settings;
using Visma.Sign.Api.Client.UnitTests.Builders.Tokens;

namespace Visma.Sign.Api.Client.UnitTests.Tokens
{
    [TestFixture]
    class OrganizationTokenTests
    {
        [Test]
        public void AskingToken_WithIdentifier_SendsRequestCorrectly()
        {
            var response = new ApiResponseStubBuilder<OrganizationsDto>()
                .WithGetResponse(new OrganizationsDtoBuilder().WithOrganizations(new OrganizationDtoBuilder()))
                .Build();
            var sut = new OrganizationTokenBuilder()
                .WithEndpoint(new EndpointStubBuilder().WithUri("https://sign.visma.net/").Build())
                .WithResponse(response)
                .Build();

            sut.Get("1234567-1").Wait();

            response.Received(1).GetResponse<OrganizationsDto>(Arg.Is<HttpRequestMessage>(value 
                => "https://sign.visma.net/api/v1/organization/?business_id=1234567-1".Equals(value.RequestUri.ToString()) &&
                   value.Method == HttpMethod.Get));
        }

        [Test]
        public void AskingToken_WithPartnerToken_SetsHeaderCorrectly()
        {
            var response = new ApiResponseStubBuilder<OrganizationsDto>()
                .WithGetResponse(new OrganizationsDtoBuilder().WithOrganizations(new OrganizationDtoBuilder()))
                .Build();
            var sut = new OrganizationTokenBuilder()
                .WithPartner(new PartnerAccessTokenStubBuilder().WithGet(new PartnerAccessTokenDtoBuilder().WithTokenType("Basic").WithAccessToken("yyyy")).Build())
                .WithResponse(response)
                .Build();

            sut.Get("").Wait();

            response.Received(1).GetResponse<OrganizationsDto>(Arg.Is<HttpRequestMessage>(value
                => value.Headers.Authorization.ToString() == "Basic yyyy"));
        }

        [Test]
        public void AskingToken_WithoutFindingAnyOrganizations_ThrowsException()
        {
            var sut = new OrganizationTokenBuilder()
                .WithResponse(new ApiResponseStubBuilder<OrganizationsDto>().WithGetResponse(new OrganizationsDtoBuilder()).Build())
                .Build();

            var actual = Assert.ThrowsAsync<OrganizationNotFoundException>(() => sut.Get("1234567-1"));
            
            Assert.AreEqual("1234567-1", actual.BusinessId);
        }

        [Test]
        public void AskingToken_WithFindingOrganization_ReturnsItsUuid()
        {
            var sut = new OrganizationTokenBuilder()
                .WithResponse(new ApiResponseStubBuilder<OrganizationsDto>()
                    .WithGetResponse(new OrganizationsDtoBuilder().WithOrganizations(new OrganizationDtoBuilder().WithUuid("xxx-xxx")))
                    .Build())
                .Build();

            var actual = sut.Get("").Result;

            Assert.AreEqual("xxx-xxx", actual);
        }

        [Test]
        public void AskingToken_WithFindingMultipleOrganizations_ReturnsFirstOrganizationsUuid()
        {
            var sut = new OrganizationTokenBuilder()
                .WithResponse(new ApiResponseStubBuilder<OrganizationsDto>()
                    .WithGetResponse(new OrganizationsDtoBuilder()
                        .WithOrganizations(new OrganizationDtoBuilder().WithUuid("yyy-yyy"))
                        .WithOrganizations(new OrganizationDtoBuilder().WithUuid("xxx-xxx")))
                    .Build())
                .Build();

            var actual = sut.Get("").Result;

            Assert.AreEqual("yyy-yyy", actual);
        }

    }
}
