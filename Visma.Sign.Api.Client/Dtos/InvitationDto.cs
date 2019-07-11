namespace Visma.Sign.Api.Client.Dtos
{
    public sealed class InvitationDto
    {
        public string email { get; set; }
        public SignatureType signature_type { get; set; }
        public string identifier_type { get; set; }
        public string sms { get; set; }
        public string name { get; set; }
        public bool? sign_as_organization { get; set; }
        public Language language { get; set; }

        public InvitationMessageDto messages { get; set; }
        public InvitationInviterDto inviter { get; set; }
        public InvitationOrderDto order { get; set; }

        public InvitationDto(
            string email,
            string sms,
            SignatureType signature,
            string name,
            Language language)
        {
            this.email = email;
            this.sms = sms;
            this.signature_type = signature;
            this.name = name;
            this.language = language;
        }

    }
}
