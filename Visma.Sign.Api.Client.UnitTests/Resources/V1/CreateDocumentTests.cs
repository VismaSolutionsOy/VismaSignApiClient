using System;
using System.Net.Http;
using NUnit.Framework;
using Visma.Sign.Api.Client.Dtos;
using Visma.Sign.Api.Client.UnitTests.Builders.Resources.V1;

namespace Visma.Sign.Api.Client.UnitTests.Resources.V1
{
    [TestFixture]
    class CreateDocumentTests
    {
        [Test]
        public void CreatingDocument_WithUri_IsExpected()
        {
            var sut = new CreateDocumentBuilder().Build();

            var actual = sut.ResourceUri;

            Assert.AreEqual("api/v1/document/", actual);
        }

        [Test]
        public void CreatingDocument_WithHttpMethod_IsExpected()
        {
            var sut = new CreateDocumentBuilder().Build();

            var actual = sut.Method;

            Assert.AreEqual(HttpMethod.Post, actual);
        }

        [Test]
        public void CreatingDocument_WithDocument_SetsContentCorrectly()
        {
            var document = new DocumentDto("Visma Sign") { category = "Contracts"};
            document.SetValidUntil(new DateTime(2019, 7, 29));
            var sut = new CreateDocumentBuilder().WithDocument(document).Build();

            var actual = sut.Content.ReadAsStringAsync().Result;

            Assert.AreEqual("{\"document\":{\"name\":\"Visma Sign\",\"category\":\"Contracts\",\"invitations_valid_until\":\"2019-07-29\"}}", actual);
        }

        [Test]
        public void CreatingDocument_WithIndefinitelyValid_SetsContentCorrectly()
        {
            var document = new DocumentDto("Visma Sign");
            document.SetValidUntil(null);
            var sut = new CreateDocumentBuilder().WithDocument(document).Build();

            var actual = sut.Content.ReadAsStringAsync().Result;

            Assert.AreEqual("{\"document\":{\"name\":\"Visma Sign\"}}", actual);
        }

        [Test]
        public void CreatingDocument_WithAffiliateCodes_SetsCodesCorrectly()
        {
            var document = new DocumentDto("Visma Sign");
            document.AddAffiliate("Solutions");
            document.AddAffiliate("SPCS");
            var sut = new CreateDocumentBuilder().WithDocument(document).Build();

            var actual = sut.Content.ReadAsStringAsync().Result;

            Assert.AreEqual("{\"document\":{\"name\":\"Visma Sign\",\"affiliates\":[{\"code\":\"Solutions\"},{\"code\":\"SPCS\"}]}}", actual);
        }
    }
}
