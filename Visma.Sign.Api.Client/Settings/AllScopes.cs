using System.Collections.Generic;

namespace Visma.Sign.Api.Client.Settings
{
    public sealed class AllScopes : IScopes
    {
        public IReadOnlyList<string> Required()
        {
            return new List<string>()
            {
                "organization_get",
                "organization_search",
                "organization_create",
                "document_get",
                "document_create",
                "document_add_file",
                "document_get_file",
                "document_create_invitations",
                "category_get_all",
                "invitee_group_get_all",
                "saved_invitation_message_get_all",
                "document_search"
            };
        }
    }
}
