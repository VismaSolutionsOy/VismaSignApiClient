using System.Net;

namespace Visma.Sign.Api.Client.Dtos
{
    public class HttpStatusCodeDto
    {
        public HttpStatusCode Code { get; }

        public HttpStatusCodeDto(HttpStatusCode code)
        {
            Code = code;
        }
    }
}
