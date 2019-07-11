using System.Net.Http;
using NUnit.Framework;
using Visma.Sign.Api.Client.Resources.V1;

namespace Visma.Sign.Api.Client.UnitTests.Resources.V1
{
    [TestFixture]
    class SearchDocumentsTests
    {
        [Test]
        public void Searching_WithHttpMethod_IsExpected()
        {
            var sut = SearchDocuments.ByParticipant("");

            var actual = sut.Method;

            Assert.AreEqual(HttpMethod.Get, actual);
        }

        [Test]
        public void Searching_WithContent_IsExpected()
        {
            var sut = SearchDocuments.ByParticipant("");

            var actual = sut.Content;

            Assert.IsNull(actual);
        }

        [Test]
        public void Searching_WithParticipant_IsExpected()
        {
            var sut = SearchDocuments.ByParticipant("example@visma.com");

            var actual = sut.ResourceUri;

            Assert.AreEqual("api/v1/document/?participant=example%40visma.com", actual);
        }
    }
}
