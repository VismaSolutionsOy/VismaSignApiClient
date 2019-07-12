using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Visma.Sign.Api.Client.Dtos;
using Visma.Sign.Api.Client.Resources.V1;
using Visma.Sign.Api.Client.Settings;
using ICredentials = Visma.Sign.Api.Client.Settings.ICredentials;

namespace Visma.Sign.Api.Client.Examples.PartnerUsage
{
    public sealed class RequestAccessToAnOrganization
    {
        private readonly IEndpoint m_endpoint;
        private readonly ICredentials m_credentials;
        private readonly ICurrentOrganization m_organization;

        public RequestAccessToAnOrganization(IEndpoint endpoint, ICredentials credentials)
        {
            m_endpoint = endpoint;
            m_credentials = credentials;
            m_organization = new HardcodedOrganization("");
        }

        public async Task RequestAccess(string businessId)
        {
            var factory = new PartnerClientFactory(m_endpoint, m_credentials, m_organization);
            var client = factory.Create();

            Console.WriteLine("Finding organization uuid for requesting access");
            var organizations = await client.SendRequest<OrganizationsDto>(new SearchOrganization(businessId));
            if (!organizations.organizations.Any())
            {
                Console.WriteLine(   $"No organizations found with '{businessId}'");
                return;
            }

            var organization = organizations.organizations.First(x => x.business_id == businessId);
            Console.WriteLine($"Requesting access to an organization with uuid: {organization.uuid}");
            var result =  
                await client.SendRequest<HttpStatusCodeDto>(new RequestAccessToOrganization(
                    organization.uuid,
                    "We would like access to your Visma Sign organization, in order to automate signing of documents.",
                    Language.English));

            if (result.Code != HttpStatusCode.Created)
            {
                Console.WriteLine($"Requesting access failed with http status code: {result.Code}");
                return;
            }

            Console.WriteLine("Starting to polling if organization has accepted our request");
            for (var times = 0; times < 3; times++)
            {
                var accessStatus = await client.SendRequest<OrganizationDto>(new GetOrganization(organization.uuid));
                Console.WriteLine($"Is access authorized: {accessStatus.authorization.authorized}");

                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }

    }
}
