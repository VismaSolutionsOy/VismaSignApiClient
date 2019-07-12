using Visma.Sign.Api.Client.Dtos;
using Visma.Sign.Api.Client.Resources.V1;

namespace Visma.Sign.Api.Client.UnitTests.Builders.Resources.V1
{
    sealed class RequestAccessToOrganizationBuilder
    {
        private string m_uuid = "";
        private string m_message = "";
        private Language m_language = Language.Finnish;

        public RequestAccessToOrganizationBuilder WithOrganizationUuid(string value)
        {
            m_uuid = value;
            return this;
        }

        public RequestAccessToOrganizationBuilder WithMessage(string value)
        {
            m_message = value;
            return this;
        }

        public RequestAccessToOrganizationBuilder WithLanguage(Language value)
        {
            m_language = value;
            return this;
        }

        public RequestAccessToOrganization Build()
            => new RequestAccessToOrganization(m_uuid, m_message, m_language);


    }
}
