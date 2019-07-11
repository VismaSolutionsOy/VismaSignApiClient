using System.Net;
using System.Net.Http;
using NSubstitute;

namespace Visma.Sign.Api.Client.UnitTests.Builders
{
    sealed class HttpClientStubBuilder
    {
        private HttpResponseMessage m_send = new HttpResponseMessage(HttpStatusCode.OK);

        public HttpClientStubBuilder WithSend(HttpResponseMessage value)
        {
            m_send = value;
            return this;
        }

        public IHttpClient Build()
        {
            var stub = Substitute.For<IHttpClient>();
            stub.SendAsync(Arg.Any<HttpRequestMessage>()).Returns(m_send);

            return stub;
        }
    }
}
