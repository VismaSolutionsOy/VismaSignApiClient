using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Visma.Sign.Api.Client.Dtos;
using Visma.Sign.Api.Client.Resources;
using Visma.Sign.Api.Client.Resources.V1;
using Visma.Sign.Api.Client.Settings;

namespace Visma.Sign.Api.Client.Tokens
{
    public sealed class OrganizationToken : IOrganizationToken
    {
        private readonly IEndpoint m_endpoint;
        private readonly IPartnerAccessToken m_partnerAccessToken;
        private readonly IApiResponse m_response;

        public OrganizationToken(IEndpoint endpoint, IPartnerAccessToken partnerAccessToken, IApiResponse response)
        {
            m_endpoint = endpoint;
            m_partnerAccessToken = partnerAccessToken;
            m_response = response;
        }

        public async Task<string> Get(string businessId)
        {
            var organization = new GetOrganization(businessId);
            var request = new HttpRequestMessage(organization.Method, m_endpoint.Uri() + organization.ResourceUri);
            request.Headers.Add("Authorization", (await m_partnerAccessToken.Get()).PartnerToken());

            var organizations = await m_response.GetResponse<OrganizationsDto>(request);
            if (!organizations.organizations.Any())
            {
                throw new OrganizationNotFoundException(businessId);
            }

            return organizations.organizations.First().uuid;
        }
    }
}
