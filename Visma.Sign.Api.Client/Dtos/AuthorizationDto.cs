using System;

namespace Visma.Sign.Api.Client.Dtos
{
    public sealed class AuthorizationDto
    {
        public bool authorized { get; set; }
        public DateTime? requested_on { get; set; }
        public DateTime? authorized_on { get; set; }
        public DateTime? canceled_on { get; set; }
    }
}
