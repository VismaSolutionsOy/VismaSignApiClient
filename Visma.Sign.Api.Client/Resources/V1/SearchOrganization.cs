using System.Net.Http;

namespace Visma.Sign.Api.Client.Resources.V1
{
    public sealed class SearchOrganization : ResourceBase
    {
        public SearchOrganization(string businessId) 
            : base("api/v1/organization/?business_id=" + UrlEncode(businessId), HttpMethod.Get)
        {}
    }
}
