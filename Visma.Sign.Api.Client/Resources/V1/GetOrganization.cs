using System.Net.Http;

namespace Visma.Sign.Api.Client.Resources.V1
{
    public sealed class GetOrganization : ResourceBase
    {
        public GetOrganization(string businessId) 
            : base("api/v1/organization/?business_id=" + businessId, HttpMethod.Get)
        {}
    }
}
