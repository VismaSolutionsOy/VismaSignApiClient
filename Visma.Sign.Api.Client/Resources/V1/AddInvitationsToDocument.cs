using System.Collections.Generic;
using System.Net.Http;
using Visma.Sign.Api.Client.Dtos;

namespace Visma.Sign.Api.Client.Resources.V1
{
    public sealed class AddInvitationsToDocument : ResourceBase
    {
        public AddInvitationsToDocument(LocationDto location, IEnumerable<InvitationDto> invitations)
            : base($"api/v1/document/{location.Uuid}/invitations", HttpMethod.Post, invitations)
        {}

    }
}
