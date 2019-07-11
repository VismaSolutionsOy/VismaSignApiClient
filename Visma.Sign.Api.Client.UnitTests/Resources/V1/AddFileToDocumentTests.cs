using System.Net.Http;
using NUnit.Framework;
using Visma.Sign.Api.Client.UnitTests.Builders.Dtos;
using Visma.Sign.Api.Client.UnitTests.Builders.Resources.V1;

namespace Visma.Sign.Api.Client.UnitTests.Resources.V1
{
    [TestFixture]
    class AddFileToDocumentTests
    {
        [Test]
        public void AddingFile_WithLocation_SetsUriCorrectly()
        {
            var sut = new AddFileToDocumentBuilder()
                .WithLocation(new LocationDtoBuilder().WithLocation("https://sign.visma.net/api/v1/document/e59c8dc8-8848-4936-ac7c-50d9ed72085a"))
                .Build();

            var actual = sut.ResourceUri;

            StringAssert.StartsWith("api/v1/document/e59c8dc8-8848-4936-ac7c-50d9ed72085a/files?", actual);
        }

        [Test]
        public void AddingFile_WithFileNAme_SetsUriCorrectly()
        {
            var sut = new AddFileToDocumentBuilder().WithFileName("secret.pdf").Build();

            var actual = sut.ResourceUri;

            StringAssert.EndsWith("?filename=secret.pdf", actual);
        }

        [Test]
        public void AddingFile_WithFileName_UrlEncodesIt()
        {
            var sut = new AddFileToDocumentBuilder().WithFileName("  .pdf").Build();

            var actual = sut.ResourceUri;

            StringAssert.EndsWith("++.pdf", actual);
        }

        [Test]
        public void AddingFile_WithHttpMethod_IsExpected()
        {
            var sut = new AddFileToDocumentBuilder().Build();

            var actual = sut.Method;

            Assert.AreEqual(HttpMethod.Post, actual);
        }

        [Test]
        public void AddingFile_WithAttachment_SetsContentCorrectly()
        {
            var sut = new AddFileToDocumentBuilder().WithAttachment(0x20).Build();

            var content = sut.Content as ByteArrayContent;

            var actualBytes = content.ReadAsByteArrayAsync().Result;
            Assert.AreEqual(new byte[] {0x20}, actualBytes);
            Assert.AreEqual("application/pdf", content.Headers.ContentType.MediaType);

        }

    }
}
