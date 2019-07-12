using System.Net;
using System.Net.Http;
using NSubstitute;
using NUnit.Framework;
using Visma.Sign.Api.Client.Dtos;
using Visma.Sign.Api.Client.UnitTests.Builders;

namespace Visma.Sign.Api.Client.UnitTests
{
    [TestFixture]
    class ApiResponseTests
    {
        [TestCase(HttpStatusCode.Moved)]
        [TestCase(HttpStatusCode.BadRequest)]
        [TestCase(HttpStatusCode.InternalServerError)]
        public void AskingResponse_WithNonSuccessStatusCode_ThrowsException(HttpStatusCode value)
        {
            var sut = new ApiResponseBuilder()
                .WithClient(new HttpClientStubBuilder().WithSend(new HttpResponseMessage(value)).Build())
                .Build();

            var actual = Assert.ThrowsAsync<HttpRequestException>(() => sut.GetResponse<object>(new HttpRequestMessage()));
        }

        [Test]
        public void AskingResponse_WithNonSuccessContent_ThrowsExceptionWithContent()
        {
            var sut = new ApiResponseBuilder()
                .WithClient(new HttpClientStubBuilder().WithSend(new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("XXX")
                }).Build())
                .Build();

            var actual = Assert.ThrowsAsync<HttpRequestException>(() => sut.GetResponse<object>(new HttpRequestMessage()));

            Assert.AreEqual("XXX", actual.Message);
        }

        [Test]
        public void AskingResponse_WithoutNonSuccessContent_ThrowsExceptionWithoutContent()
        {
            var sut = new ApiResponseBuilder()
                .WithClient(new HttpClientStubBuilder().WithSend(new HttpResponseMessage(HttpStatusCode.BadRequest)).Build())
                .Build();

            var actual = Assert.ThrowsAsync<HttpRequestException>(() => sut.GetResponse<object>(new HttpRequestMessage()));

            Assert.AreEqual("", actual.Message);
        }

        [Test]
        public void AskingResponse_WithLocation_ReturnsExpected()
        {
            var response = new HttpResponseMessage();
            response.Headers.Add("Location", "https://sign.visma.net/");
            var sut = new ApiResponseBuilder()
                .WithClient(new HttpClientStubBuilder().WithSend(response).Build())
                .Build();

            var actual = sut.GetResponse<LocationDto>(new HttpRequestMessage()).Result;

            Assert.AreEqual("https://sign.visma.net/", actual.Location.ToString());
        }

        [Test]
        public void AskingResponse_WithHttpStatus_ReturnsExpected()
        {
            var sut = new ApiResponseBuilder()
                .WithClient(new HttpClientStubBuilder().WithSend(new HttpResponseMessage(HttpStatusCode.BadRequest)).Build())
                .Build();

            var actual = sut.GetResponse<HttpStatusCodeDto>(new HttpRequestMessage()).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, actual.Code);
        }

        [Test]
        public void AskingResponse_WithSuccessfulResponse_SerializesCorrectly()
        {
            var sut = new ApiResponseBuilder()
                .WithClient(new HttpClientStubBuilder().WithSend(new HttpResponseMessage()
                {
                    Content = new StringContent("{\"uuid\":\"e59c8dc8-8848-4936-ac7c-50d9ed72085a\",\"name\":\"Test document\",\"status\":\"pending\"}")
                }).Build())
                .Build();

            var actual = sut.GetResponse<DocumentStatusDto>(new HttpRequestMessage()).Result;

            Assert.AreEqual("pending", actual.status);
            Assert.AreEqual("Test document", actual.name);
            Assert.AreEqual("e59c8dc8-8848-4936-ac7c-50d9ed72085a", actual.uuid);
        }

        [Test]
        public void AskingResponse_WithRequestMessage_CallsClientCorrectly()
        {
            var expected = new HttpRequestMessage();
            var response = new HttpResponseMessage();
            response.Headers.Add("Location", "https://sign.visma.net/");
            var client = new HttpClientStubBuilder().WithSend(response).Build();
            var sut = new ApiResponseBuilder().WithClient(client).Build();

            sut.GetResponse<LocationDto>(expected).Wait();

            client.Received(1).SendAsync(expected);
        }

    }
}
