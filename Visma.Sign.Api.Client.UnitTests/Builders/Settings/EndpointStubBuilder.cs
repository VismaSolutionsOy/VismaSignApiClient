using System;
using NSubstitute;
using Visma.Sign.Api.Client.Settings;

namespace Visma.Sign.Api.Client.UnitTests.Builders.Settings
{
    sealed class EndpointStubBuilder
    {
        private Uri m_uri = new Uri("https://sign.visma.net/fi");

        public EndpointStubBuilder WithUri(string value)
        {
            m_uri = new Uri(value);
            return this;
        }

        public IEndpoint Build()
        {
            var stub = Substitute.For<IEndpoint>();
            stub.Uri().Returns(m_uri);

            return stub;
        }
    }
}
