using System.Net.Http;

namespace Visma.Sign.Api.Client.UnitTests.Builders
{
    sealed class ResourceBaseBuilder
    {
        private string m_resourceUri = "";
        private HttpMethod m_method = HttpMethod.Get;
        private object m_requestBody = null;

        public ResourceBaseBuilder WithResourceUri(string value)
        {
            m_resourceUri = value;
            return this;
        }

        public ResourceBaseBuilder WithMethod(HttpMethod value)
        {
            m_method = value;
            return this;
        }

        public ResourceBaseBuilder WithRequestBody(object value)
        {
            m_requestBody = value;
            return this;
        }

        public ResourceBase Build()
        {
            return new TestingResourceBase(m_resourceUri, m_method, m_requestBody);
        }

        public static implicit operator ResourceBase(ResourceBaseBuilder b)
            => b.Build();

        private class TestingResourceBase : ResourceBase
        {
            public TestingResourceBase(string resourceUri, HttpMethod method, object requestBody)
                : base(resourceUri, method, requestBody)
            { }
        }
    }
}
