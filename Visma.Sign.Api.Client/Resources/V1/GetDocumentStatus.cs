using System.Net.Http;

namespace Visma.Sign.Api.Client.Resources.V1
{
    public sealed class GetDocumentStatus : ResourceBase
    {
        public GetDocumentStatus(string documentUuid)
            : base($"api/v1/document/{UrlEncode(documentUuid)}", HttpMethod.Get)
        { }
    }
}
