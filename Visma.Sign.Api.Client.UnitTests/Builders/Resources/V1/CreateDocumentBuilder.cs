using Visma.Sign.Api.Client.Dtos;
using Visma.Sign.Api.Client.Resources.V1;

namespace Visma.Sign.Api.Client.UnitTests.Builders.Resources.V1
{
    sealed class CreateDocumentBuilder
    {
        private DocumentDto m_document = new DocumentDto("Test");

        public CreateDocumentBuilder WithDocument(DocumentDto value)
        {
            m_document = value;
            return this;
        }

        public CreateDocument Build()
            => new CreateDocument(m_document);

    }
}
