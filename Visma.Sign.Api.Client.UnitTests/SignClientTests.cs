using System.Net.Http;
using NSubstitute;
using NUnit.Framework;
using Visma.Sign.Api.Client.UnitTests.Builders;

namespace Visma.Sign.Api.Client.UnitTests
{
    [TestFixture]
    class SignClientTests
    {
        [Test]
        public void SendingRequest_WithGivenResource_CallsRequestCorrectly()
        {
            var expected = new ResourceBaseBuilder().Build();
            var request = new ApiRequestStubBuilder().Build();
            var sut = new SignClientBuilder().WithRequest(request).Build();

            sut.SendRequest<object>(expected).Wait();

            request.Received(1).Create(expected);
        }

        [Test]
        public void SendingRequest_WithHttpRequestMessage_CallsResponseCorrectly()
        {
            var expected = new HttpRequestMessage();
            var response = new ApiResponseStubBuilder<object>().Build();
            var sut = new SignClientBuilder()
                .WithRequest(new ApiRequestStubBuilder().WithCreate(expected).Build())
                .WithResponse(response)
                .Build();

            sut.SendRequest<object>(new ResourceBaseBuilder()).Wait();

            response.Received(1).GetResponse<object>(expected);
        }

        [Test]
        public void SendingRequest_WithResponse_ReturnsExpected()
        {
            var expected = new ResourceBaseBuilder().Build();
            var sut = new SignClientBuilder()
                .WithResponse(new ApiResponseStubBuilder<ResourceBase>().WithGetResponse(expected).Build())
                .Build();

            var actual = sut.SendRequest<ResourceBase>(new ResourceBaseBuilder()).Result;

            Assert.AreEqual(expected, actual);
        }
    }
}
