using System.Net.Http;
using NUnit.Framework;
using Visma.Sign.Api.Client.UnitTests.Builders.Resources.V1;
using Visma.Sign.Api.Client.UnitTests.Builders.Settings;

namespace Visma.Sign.Api.Client.UnitTests.Resources.V1
{
    [TestFixture]
    class RequestAuthorizationTests
    {
        [Test]
        public void RequestingAuthorization_WithGivenUrl_IsExpected()
        {
            var sut = new RequestAuthorizationBuilder().Build();

            var actual = sut.ResourceUri;

            Assert.AreEqual("api/v1/auth/token", actual);
        }

        [Test]
        public void RequestingAuthorization_WithHttpMethod_IsExpected()
        {
            var sut = new RequestAuthorizationBuilder().Build();

            var actual = sut.Method;

            Assert.AreEqual(HttpMethod.Post, actual);
        }

        [Test]
        public void RequestingAuthorization_WithGrantType_SetsContentCorrectly()
        {
            var sut = new RequestAuthorizationBuilder().Build();

            var actual = sut.Content.ReadAsStringAsync().Result;

            StringAssert.StartsWith("grant_type=client_credentials", actual);
        }

        [Test]
        public void RequestingAuthorization_WithCredentials_SetsContentCorrectly()
        {
            var sut = new RequestAuthorizationBuilder()
                .WithCredentials(new CredentialsStubBuilder().WithIdentifier("identifier").WithSecret("secret").Build())
                .Build();

            var actual = sut.Content.ReadAsStringAsync().Result;

            StringAssert.Contains("&client_id=identifier", actual);
            StringAssert.Contains("&client_secret=secret", actual);
        }

        [Test]
        public void RequestingAuthorization_WithSingleScope_SetsContentCorrectly()
        {
            var sut = new RequestAuthorizationBuilder()
                .WithScopes(new ScopesStubBuilder().WithRequired("document_create").Build())
                .Build();

            var actual = sut.Content.ReadAsStringAsync().Result;

            StringAssert.EndsWith("&scope=document_create", actual);
        }

        [Test]
        public void RequestingAuthorization_WithMultipleScopes_SetsContentCorrectly()
        {
            var sut = new RequestAuthorizationBuilder()
                .WithScopes(new ScopesStubBuilder().WithRequired("document_create", "document_add_file", "document_create_invitations").Build())
                .Build();

            var actual = sut.Content.ReadAsStringAsync().Result;

            StringAssert.EndsWith("&scope=document_create document_add_file document_create_invitations", actual);
        }

        [Test]
        public void RequestingAuthorization_WithContent_SetsMediaTypeCorrectly()
        {
            var sut = new RequestAuthorizationBuilder().Build();

            var actual = sut.Content.Headers.ContentType.MediaType;

            Assert.AreEqual("application/x-www-form-urlencoded", actual);
        }
    }
}
