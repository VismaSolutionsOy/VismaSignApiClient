using Visma.Sign.Api.Client.Resources.V1;

namespace Visma.Sign.Api.Client.UnitTests.Builders.Resources.V1
{
    sealed class GetDocumentStatusBuilder
    {
        private string m_uuid = "1234";

        public GetDocumentStatusBuilder WithDocumentUuid(string value)
        {
            m_uuid = value;
            return this;
        }

        public GetDocumentStatus Build()
            => new GetDocumentStatus(m_uuid);
    }
}
