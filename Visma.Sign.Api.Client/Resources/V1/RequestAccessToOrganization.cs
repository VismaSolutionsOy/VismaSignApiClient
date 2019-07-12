using System.Net.Http;
using Visma.Sign.Api.Client.Dtos;

namespace Visma.Sign.Api.Client.Resources.V1
{
    public class RequestAccessToOrganization : ResourceBase
    {
        public RequestAccessToOrganization(string organizationUuid, string message, Language language)
            : base($"api/v1/organization/{organizationUuid}/client-authorization?lang={LanguageString.Get(language)}",
                HttpMethod.Post, 
                new {message})
        {}
    }
}
