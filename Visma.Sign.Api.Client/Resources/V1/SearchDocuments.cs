using System.Net.Http;
using System.Web;

namespace Visma.Sign.Api.Client.Resources.V1
{
    public sealed class SearchDocuments : ResourceBase
    {
        public static SearchDocuments ByParticipant(string value) 
            => new SearchDocuments("participant", value);

        private SearchDocuments(string parameter, string value)
            : base("api/v1/document/?" + UrlEncode(parameter, value), HttpMethod.Get)
        { }


    }
}
