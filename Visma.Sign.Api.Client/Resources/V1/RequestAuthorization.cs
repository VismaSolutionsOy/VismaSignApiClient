using System.Net.Http;
using Visma.Sign.Api.Client.Settings;

namespace Visma.Sign.Api.Client.Resources.V1
{
    public sealed class RequestAuthorization : ResourceBase
    {
        public RequestAuthorization(ICredentials credentials, IScopes requestedScopes)
            : base(
                "api/v1/auth/token",
                HttpMethod.Post,
                "grant_type=client_credentials" + 
                    $"&client_id={credentials.Identifier()}" +
                    $"&client_secret={credentials.Secret()}" +
                    $"&scope={string.Join(" ", requestedScopes.Required())}")
        {}
    }
}
