using System.Net.Http;

namespace Visma.Sign.Api.Client.Resources.V1
{
    public sealed class GetOrganization : ResourceBase
    {
        public GetOrganization(string organizationUuid) : 
            base($"api/v1/organization/{UrlEncode(organizationUuid)}", HttpMethod.Get)
        { }
    }
}
