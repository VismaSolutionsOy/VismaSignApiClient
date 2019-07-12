using System.Collections.Generic;

namespace Visma.Sign.Api.Client.Dtos
{
    public class DocumentStatusDto
    {
        public string uuid { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public List<FilenameDto> files { get; set; }
        public List<InvitationDto> invitations { get; set; }

        public DocumentStatusDto()
        {
            files = new List<FilenameDto>();
            invitations = new List<InvitationDto>();
        }
    }
}
