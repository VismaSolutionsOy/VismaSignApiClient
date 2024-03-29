﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Visma.Sign.Api.Client.Dtos;
using Visma.Sign.Api.Client.Resources.V1;

namespace Visma.Sign.Api.Client.Examples.PartnerExamples
{
    public sealed class DocumentCreation
    {
        private readonly ISignClient m_client;

        public DocumentCreation(ISignClient client)
        {
            m_client = client;
        }

        public async Task CreateDocumentAndGetStatus()
        {
            Console.WriteLine("Creating new document");
            var documentInformation = new DocumentDto("Example");
            var documentLocation = await m_client.SendRequest<LocationDto>(new CreateDocument(documentInformation));

            Console.WriteLine("Adding new file for created document");
            var attachment = await new HttpClient().GetByteArrayAsync("https://sign.visma.net/empty.pdf");
            var attachmentUuid = await m_client.SendRequest<IdentifierDto>(new AddFileToDocument(documentLocation, "empty.pdf", attachment));

            Console.WriteLine("Creating invitations for document");
            var invitations = new AddInvitationsToDocument(documentLocation, new List<InvitationDto>()
            {
                new InvitationDto("test@visma.com", null, SignatureType.Strong, "John Visma", Language.Finnish),
            });
            var createdInvitations = await m_client.SendRequest<List<InvitationCreatedDto>>(invitations);
            foreach (var invitation in createdInvitations)
            {
                Console.WriteLine($"Invitation '{invitation.uuid}' created");
            }

            Console.Write("Asking document status...");
            var documentStatus = await m_client.SendRequest<DocumentStatusDto>(new GetDocumentStatus(documentLocation.Uuid));
            Console.WriteLine($" status is: {documentStatus.status}");
        }
    }
}
