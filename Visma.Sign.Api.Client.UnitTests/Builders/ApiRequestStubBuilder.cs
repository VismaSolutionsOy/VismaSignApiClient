using System.Net.Http;
using NSubstitute;

namespace Visma.Sign.Api.Client.UnitTests.Builders
{
    sealed class ApiRequestStubBuilder
    {
        private HttpRequestMessage m_create = new HttpRequestMessage();

        public ApiRequestStubBuilder WithCreate(HttpRequestMessage value)
        {
            m_create = value;
            return this;
        }

        public IApiRequest Build()
        {
            var stub = Substitute.For<IApiRequest>();
            stub.Create(Arg.Any<ResourceBase>()).Returns(m_create);

            return stub;
        }
    }
}
