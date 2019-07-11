using System.Collections.Generic;
using System.Linq;
using Visma.Sign.Api.Client.Dtos;
using Visma.Sign.Api.Client.Resources.V1;
using Visma.Sign.Api.Client.UnitTests.Builders.Dtos;

namespace Visma.Sign.Api.Client.UnitTests.Builders.Resources.V1
{
    sealed class AddInvitationsToDocumentBuilder
    {
        private LocationDto m_location = new LocationDtoBuilder();
        private List<InvitationDto> m_invitations = new List<InvitationDto>();

        public AddInvitationsToDocumentBuilder WithLocation(LocationDto value)
        {
            m_location = value;
            return this;
        }

        public AddInvitationsToDocumentBuilder WithInvitation(params InvitationDto[] value)
        {
            m_invitations.AddRange(value.ToArray());
            return this;
        }

        public AddInvitationsToDocument Build()
            => new AddInvitationsToDocument(m_location, m_invitations);
    }
}
