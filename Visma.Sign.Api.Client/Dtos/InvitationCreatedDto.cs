namespace Visma.Sign.Api.Client.Dtos
{
    public sealed class InvitationCreatedDto
    {
        public string uuid { get; set; }
        public string status { get; set; }
        public string passphrase { get; set; }
    }
}
