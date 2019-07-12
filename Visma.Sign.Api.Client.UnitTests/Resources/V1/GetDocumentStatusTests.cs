using System.Net.Http;
using NUnit.Framework;
using Visma.Sign.Api.Client.UnitTests.Builders.Resources.V1;

namespace Visma.Sign.Api.Client.UnitTests.Resources.V1
{
    [TestFixture]
    class GetDocumentStatusTests
    {
        [Test]
        public void GettingStatus_WithHttpMethod_IsExpected()
        {
            var sut = new GetDocumentStatusBuilder().Build();

            var actual = sut.Method;

            Assert.AreEqual(HttpMethod.Get, actual);
        }

        [Test]
        public void GettingStatus_WithUuid_SetsUriCorrectly()
        {
            var sut = new GetDocumentStatusBuilder().WithDocumentUuid("xxx-yyy").Build();

            var actual = sut.ResourceUri;

            Assert.AreEqual("api/v1/document/xxx-yyy", actual);

        }
    }
}
