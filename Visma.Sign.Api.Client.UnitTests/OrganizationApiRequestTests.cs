using System;
using System.Net.Http;
using NUnit.Framework;
using Visma.Sign.Api.Client.UnitTests.Builders;
using Visma.Sign.Api.Client.UnitTests.Builders.Resources.V1;
using Visma.Sign.Api.Client.UnitTests.Builders.Settings;

namespace Visma.Sign.Api.Client.UnitTests
{
    [TestFixture]
    class OrganizationApiRequestTests
    {
        [Test]
        public void Creating_WithEndpointAndResource_SetsUriCorrectly()
        {
            var resource = new ResourceBaseBuilder().WithResourceUri("api/v1/document");
            var sut = new OrganizationApiRequestBuilder()
                .WithEndpoint(new EndpointStubBuilder().WithUri("https://sign.visma.net").Build())
                .Build();

            var actual = sut.Create(resource).Result.RequestUri.ToString();

            Assert.AreEqual("https://sign.visma.net/api/v1/document", actual);
        }

        [Test]
        public void Creating_WithResourceMethod_SetsHttpMethodCorrectly()
        {
            var sut = new OrganizationApiRequestBuilder().Build();

            var actual = sut.Create(new ResourceBaseBuilder().WithMethod(HttpMethod.Delete)).Result.Method;

            Assert.AreEqual(HttpMethod.Delete, actual);
        }

        [Test]
        public void Creating_WithTime_SetsRequestDateCorrectly()
        {
            var sut = new OrganizationApiRequestBuilder()
                .WithTime(new TimeProviderStubBuilder().WithUtcNow(2019, 7, 29).Build())
                .Build();

            var actual = sut.Create(new ResourceBaseBuilder()).Result.Headers.Date?.Date;

            Assert.AreEqual(new DateTime(2019, 7, 29), actual);
        }

        [Test]
        public void Creating_WithResourceContent_SetsContentCorrectly()
        {
            var sut = new OrganizationApiRequestBuilder().Build();

            var actual = sut.Create(new ResourceBaseBuilder().WithRequestBody(new {message = "example"})).Result.Content.ReadAsStringAsync().Result;

            Assert.AreEqual("{\"message\":\"example\"}", actual);
        }

        [Test]
        public void Creating_WithResourceContent_CalculatesMacCorrectly()
        {
            var sut = new OrganizationApiRequestBuilder().Build();

            var actual = sut.Create(new ResourceBaseBuilder().WithRequestBody(new { message = "example" })).Result.Content.Headers.ContentMD5;

            var expected = new byte[] {27, 69, 217, 58, 170, 162, 2, 172, 158, 26, 32, 68, 2, 49, 74, 11};
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Creating_WithoutResourceHavingContent_DoesNotSetContent()
        {
            var sut = new OrganizationApiRequestBuilder().Build();

            var actual = sut.Create(new GetOrganizationBuilder()).Result.Content;

            Assert.IsNull(actual);
        }

        [Test]
        public void Creating_WithResourceHavingContent_SetsAuthorizationCorrectly()
        {
            var resource = new ResourceBaseBuilder().WithMethod(HttpMethod.Post).WithResourceUri("api/v1/document").WithRequestBody(new { message = "example" });
            var sut = new OrganizationApiRequestBuilder()
                .WithCredentials(new CredentialsStubBuilder().WithIdentifier("identifier").WithSecret("").Build())
                .WithTime(new TimeProviderStubBuilder().WithUtcNow(new DateTime(2019, 1, 1)).Build())
                .Build();

            var actual = sut.Create(resource).Result.Headers.Authorization.ToString();

            Assert.AreEqual("Onnistuu identifier:+cnVjVc6+cj39lQ7MpJi4SgPaxqW+AsEU6ndAouSPGWVU5DoU9GUeIgAQih+rbktFE4jV6+r91WnG2mfnkdDmA==", actual);
        }


        [Test]
        public void Creating_WithoutResourceHavingContent_SetsAuthorizationCorrectly()
        {
            var sut = new OrganizationApiRequestBuilder()
                .WithCredentials(new CredentialsStubBuilder().WithIdentifier("identifier").WithSecret("").Build())
                .WithTime(new TimeProviderStubBuilder().WithUtcNow(new DateTime(2019, 1, 1)).Build())
                .Build();

            var actual = sut.Create(new GetOrganizationBuilder()).Result.Headers.Authorization.ToString();

            Assert.AreEqual("Onnistuu identifier:Es5mhE3uAHUtPa5EKfQfJIYZE//sQMybbIUaR0SiORly5+JfZPZNjKCwEB65PTfi3cAeYR43bXPSTEXa9PoQMA==", actual);
        }
    }
}
