using System.Linq;
using Visma.Sign.Api.Client.Dtos;
using Visma.Sign.Api.Client.Resources.V1;
using Visma.Sign.Api.Client.UnitTests.Builders.Dtos;

namespace Visma.Sign.Api.Client.UnitTests.Builders.Resources.V1
{
    sealed class AddFileToDocumentBuilder
    {
        private LocationDto m_location = new LocationDtoBuilder();
        private string m_fileName = "";
        private byte[] m_attachment = { };

        public AddFileToDocumentBuilder WithLocation(LocationDto value)
        {
            m_location = value;
            return this;
        }

        public AddFileToDocumentBuilder WithFileName(string value)
        {
            m_fileName = value;
            return this;
        }

        public AddFileToDocumentBuilder WithAttachment(params byte[] value)
        {
            m_attachment = value.ToArray();
            return this;
        }

        public AddFileToDocument Build()
            => new AddFileToDocument(m_location, m_fileName, m_attachment);

    }
}
