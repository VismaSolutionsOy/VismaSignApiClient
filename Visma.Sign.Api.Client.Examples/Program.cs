using System;
using System.Collections.Generic;
using Visma.Sign.Api.Client.Examples.PartnerExamples;
using Visma.Sign.Api.Client.Settings;
using Visma.Sign.Api.Client.Tokens;

namespace Visma.Sign.Api.Client.Examples
{
    class Program
    {
        private static readonly Uri Endpoint = new Uri("");
        private const string ClientId = "";
        private const string ClientSecret = "";
        private const string CurrentBusinessId = "";

        private const string NoOrganizationSelected = "";

        static void Main(string[] args)
        {
            //PartnerExamples();
            OrganizationExamples();
            Console.Read();
        }

        static void PartnerExamples()
        {
            ////1. Request access to an organization
            //var client = CreatePartnerClient(NoOrganizationSelected);
            //new PartnerExamples.RequestAccessToAnOrganization(client).RequestAccess("Fill business id").Wait();

            ////2. Create new document
            //var client = CreatePartnerClient(CurrentBusinessId);
            //new PartnerExamples.DocumentCreation(client).CreateDocumentAndGetStatus().Wait();
        }

        static void OrganizationExamples()
        {
            //2. Create new document
            //var client = CreateOrganizationClient();
            //new OrganizationExamples.DocumentCreation(client).CreateDocumentAndGetStatus().Wait();
        }

        private static ISignClient CreatePartnerClient(string currentBusinessI)
        {
            var credentials = new InMemoryCredentials(ClientId, ClientSecret);
            var uri = new InMemoryEndpoint(Endpoint);

            var response = new ApiResponse(new HttpClientAdapter());
            var partnerToken = new MemoryCachedPartnerAccessToken(
                new PartnerAccessToken(credentials, uri, response, new AllScopes()),
                new CurrentTimeProvider());
            var organizationToken = new MemoryCachedOrganizationToken(new OrganizationToken(uri, partnerToken, response));

            return new SignClient(
                new PartnerApiRequest(
                    organizationToken,
                    partnerToken,
                    uri,
                    new InMemoryOrganization(currentBusinessI)),
                response);
        }

        private static ISignClient CreateOrganizationClient()
        {
            var credentials = new InMemoryCredentials(ClientId, ClientSecret);
            var uri = new InMemoryEndpoint(Endpoint);
            var response = new ApiResponse(new HttpClientAdapter());
            return new SignClient(
                new OrganizationApiRequest(
                    credentials,
                    uri,
                    new CurrentTimeProvider()),
                response);
        }
    }
}
