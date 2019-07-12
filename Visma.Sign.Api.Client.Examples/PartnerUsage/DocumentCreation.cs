using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Visma.Sign.Api.Client.Dtos;
using Visma.Sign.Api.Client.Resources.V1;
using Visma.Sign.Api.Client.Settings;

namespace Visma.Sign.Api.Client.Examples.PartnerUsage
{
    public sealed class DocumentCreation
    {
        private readonly IEndpoint m_endpoint;
        private readonly ICredentials m_credentials;
        private readonly ICurrentOrganization m_organization;

        public DocumentCreation(IEndpoint endpoint, ICredentials credentials, ICurrentOrganization organization)
        {
            m_endpoint = endpoint;
            m_credentials = credentials;
            m_organization = organization;
        }

        public async Task CreateDocumentAndGetStatus()
        {
            var client = new PartnerClientFactory(m_endpoint, m_credentials, m_organization).Create();

            Console.WriteLine("Creating new document");
            var documentInformation = new DocumentDto("Example");
            var documentLocation = await client.SendRequest<LocationDto>(new CreateDocument(documentInformation));

            Console.WriteLine("Adding new file for created document");
            var attachment = await new HttpClient().GetByteArrayAsync("https://sign.visma.net/empty.pdf");
            var attachmentUuid = await client.SendRequest<IdentifierDto>(new AddFileToDocument(documentLocation, "empty.pdf", attachment));

            Console.WriteLine("Creating invitations for document");
            var invitations = new AddInvitationsToDocument(documentLocation, new List<InvitationDto>()
            {
                new InvitationDto("test@visma.com", null, SignatureType.Strong, "John Visma", Language.Finnish),
            });
            var createdInvitations = await client.SendRequest<List<InvitationCreatedDto>>(invitations);
            foreach (var invitation in createdInvitations)
            {
                Console.WriteLine($"Invitation '{invitation.uuid}' created");
            }

            Console.Write("Asking document status...");
            var documentStatus = await client.SendRequest<DocumentStatusDto>(new GetDocumentStatus(documentLocation.Uuid));
            Console.WriteLine($" status is: {documentStatus.status}");
        }


    }
}
