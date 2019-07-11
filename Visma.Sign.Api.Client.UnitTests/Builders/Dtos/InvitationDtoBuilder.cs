using Visma.Sign.Api.Client.Dtos;

namespace Visma.Sign.Api.Client.UnitTests.Builders.Dtos
{
    sealed class InvitationDtoBuilder
    {
        private string m_email = null;
        private string m_sms = null;
        private SignatureType m_signature = SignatureType.Strong;
        private string m_name = null;
        private bool? m_signAsOrganization = null;
        private Language m_language = Language.Finnish;
        private InvitationInviterDto m_inviter = null;
        private InvitationMessageDto m_messages = null;
        private InvitationOrderDto m_order = null;

        public InvitationDtoBuilder WithEmail(string value)
        {
            m_email = value;
            return this;
        }

        public InvitationDtoBuilder WithSms(string value)
        {
            m_sms = value;
            return this;
        }

        public InvitationDtoBuilder WithSignature(SignatureType value)
        {
            m_signature = value;
            return this;
        }

        public InvitationDtoBuilder WithUserName(string value)
        {
            m_name = value;
            return this;
        }

        public InvitationDtoBuilder WithSignAsOrganization(bool? value)
        {
            m_signAsOrganization = value;
            return this;
        }

        public InvitationDtoBuilder WithLanguage(Language value)
        {
            m_language = value;
            return this;
        }

        public InvitationDtoBuilder WithInviter(InvitationInviterDto value)
        {
            m_inviter = value;
            return this;
        }

        public InvitationDtoBuilder WithMessages(InvitationMessageDto value)
        {
            m_messages = value;
            return this;
        }

        public InvitationDtoBuilder WithOrder(InvitationOrderDto value)
        {
            m_order = value;
            return this;
        }

        public InvitationDto Build()
            => new InvitationDto(m_email, m_sms, m_signature, m_name, m_language)
            {
                sign_as_organization = m_signAsOrganization,
                inviter = m_inviter,
                messages = m_messages,
                order = m_order
            };

        public static implicit operator InvitationDto(InvitationDtoBuilder b)
            => b.Build();

    }
}
