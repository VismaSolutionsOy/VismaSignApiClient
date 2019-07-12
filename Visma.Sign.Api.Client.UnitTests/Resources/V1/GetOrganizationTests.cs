using System.Net.Http;
using NUnit.Framework;
using Visma.Sign.Api.Client.UnitTests.Builders.Resources.V1;

namespace Visma.Sign.Api.Client.UnitTests.Resources.V1
{
    [TestFixture]
    class GetOrganizationTests
    {
        [Test]
        public void GettingOrganization_WithHttpMethod_IsExpected()
        {
            var sut = new GetOrganizationBuilder().Build();

            var actual = sut.Method;

            Assert.AreEqual(HttpMethod.Get, actual);
        }

        [Test]
        public void GettingOrganization_WithOrganizationUuid_SetsUriCorrectly()
        {
            var sut = new GetOrganizationBuilder().WithOrganizationUuid("xxx-yyy").Build();

            var actual = sut.ResourceUri;

            Assert.AreEqual("api/v1/organization/xxx-yyy", actual);
        }

    }
}
