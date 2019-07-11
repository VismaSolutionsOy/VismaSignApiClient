using System.Collections.Generic;

namespace Visma.Sign.Api.Client.Dtos
{
    public sealed class DocumentListDto
    {
        public int total { get; set; }
        public int offset { get; set; }
        public int length { get; set; }
        public List<DocumentStatusDto> documents { get; set; }
    }
}
