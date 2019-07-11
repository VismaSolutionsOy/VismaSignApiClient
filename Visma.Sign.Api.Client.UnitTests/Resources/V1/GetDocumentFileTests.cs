using System.Net.Http;
using NUnit.Framework;
using Visma.Sign.Api.Client.Resources.V1;

namespace Visma.Sign.Api.Client.UnitTests.Resources.V1
{
    [TestFixture]
    class GetDocumentFileTests
    {
        [Test]
        public void GettingDocument_WithDocumentInformation_SetsUriCorrectly()
        {
            var sut = GetDocumentFile.FromDocument("e59c8dc8-8848-4936-ac7c-50d9ed72085a", 0);

            var actual = sut.ResourceUri;

            Assert.AreEqual("api/v1/document/e59c8dc8-8848-4936-ac7c-50d9ed72085a/files/0", actual);
        }

        [Test]
        public void GettingDocument_WithHttpMethod_IsExpected()
        {
            var sut = GetDocumentFile.FromDocument("e59c8dc8-8848-4936-ac7c-50d9ed72085a", 0);

            var actual = sut.Method;

            Assert.AreEqual(HttpMethod.Get, actual);
        }

        [Test]
        public void GettingDocument_WithContent_IsNull()
        {
            var sut = GetDocumentFile.FromDocument("e59c8dc8-8848-4936-ac7c-50d9ed72085a", 0);

            var actual = sut.Content;

            Assert.IsNull(actual);
        }
    }
}
