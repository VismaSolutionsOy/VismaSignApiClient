namespace Visma.Sign.Api.Client.Dtos
{
    public sealed class InvitationMessageDto
    {
        public bool? send_invitation_email { get; set; }
        public string invitation_email_message { get; set; }
        public bool? send_invitation_sms { get; set; }
        public string custom_sms { get; set; }
        public bool? separate_invite_parts { get; set; }
        public bool? send_invitee_all_collected_email { get; set; }
        public bool? send_inviter_one_collected_emails { get; set; }
        public bool? attachment_allowed { get; set; }
    }
}
