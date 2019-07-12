using System.Net.Http;
using NUnit.Framework;
using Visma.Sign.Api.Client.UnitTests.Builders.Resources.V1;

namespace Visma.Sign.Api.Client.UnitTests.Resources.V1
{
    [TestFixture]
    class SearchOrganizationTests
    {
        [Test]
        public void AskingOrganization_WithGivenBusinessId_SetsResourceUriCorrectly()
        {
            var sut = new SearchOrganizationBuilder().WithBusinessId("3122704-8").Build();

            var actual = sut.ResourceUri;

            Assert.AreEqual("api/v1/organization/?business_id=3122704-8", actual);
        }

        [Test]
        public void AskingOrganization_WithHttpMethod_IsExpected()
        {
            var sut = new SearchOrganizationBuilder().Build();

            var actual = sut.Method;

            Assert.AreEqual(HttpMethod.Get, actual);
        }
    }
}
