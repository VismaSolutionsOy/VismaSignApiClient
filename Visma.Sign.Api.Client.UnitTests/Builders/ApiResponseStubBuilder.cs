using System.Net.Http;
using NSubstitute;

namespace Visma.Sign.Api.Client.UnitTests.Builders
{
    sealed class ApiResponseStubBuilder<T> where T : class
    {
        private T m_getResponse = default(T);

        public ApiResponseStubBuilder<T> WithGetResponse(T value)
        {
            m_getResponse = value;
            return this;
        }

        public IApiResponse Build()
        {
            var stub = Substitute.For<IApiResponse>();
            stub.GetResponse<T>(Arg.Any<HttpRequestMessage>()).Returns(m_getResponse);

            return stub;
        }
    }
}
