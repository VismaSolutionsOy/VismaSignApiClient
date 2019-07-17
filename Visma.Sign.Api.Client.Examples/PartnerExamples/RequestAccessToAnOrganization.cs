using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Visma.Sign.Api.Client.Dtos;
using Visma.Sign.Api.Client.Resources.V1;

namespace Visma.Sign.Api.Client.Examples.PartnerExamples
{
    public sealed class RequestAccessToAnOrganization
    {
        private readonly ISignClient m_client;

        public RequestAccessToAnOrganization(ISignClient client)
        {
            m_client = client;
        }

        public async Task RequestAccess(string businessId)
        {

            Console.WriteLine("Finding organization uuid for requesting access");
            var organizations = await m_client.SendRequest<OrganizationsDto>(new SearchOrganization(businessId));
            if (!organizations.organizations.Any())
            {
                Console.WriteLine(   $"No organizations found with '{businessId}'");
                return;
            }

            var organization = organizations.organizations.First(x => x.business_id == businessId);
            Console.WriteLine($"Requesting access to an organization with uuid: {organization.uuid}");
            var result =  
                await m_client.SendRequest<HttpStatusCodeDto>(new RequestAccessToOrganization(
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
                var accessStatus = await m_client.SendRequest<OrganizationDto>(new GetOrganization(organization.uuid));
                Console.WriteLine($"Is access authorized: {accessStatus.authorization.authorized}");

                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }

    }
}
