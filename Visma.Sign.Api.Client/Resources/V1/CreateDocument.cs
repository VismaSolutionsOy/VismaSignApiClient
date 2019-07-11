using System.Net.Http;
using Visma.Sign.Api.Client.Dtos;

namespace Visma.Sign.Api.Client.Resources.V1
{
    public sealed class CreateDocument : ResourceBase
    {
        public CreateDocument(DocumentDto document) : 
            base("api/v1/document/", HttpMethod.Post, new { document })
        {}
    }
}
