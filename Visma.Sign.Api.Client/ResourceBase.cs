using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Visma.Sign.Api.Client
{
    public abstract class ResourceBase
    {
        public string ResourceUri { get; }
        public HttpMethod Method { get; }
        public HttpContent Content { get; }

        protected ResourceBase(string resourceUri, HttpMethod method, object requestBody)
            : this(resourceUri, method)
        {
            var json = ToJson(requestBody);
            Content = new StringContent(json, Encoding.UTF8, "application/json");
        }

        private static string ToJson(object requestBody)
        {
            var settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Converters = new List<JsonConverter>() {new StringEnumConverter()}
            };
            return JsonConvert.SerializeObject(requestBody, settings);
        }

        protected ResourceBase(string resourceUri, HttpMethod method, string requestBody)
            : this(resourceUri, method)
        {
            Content = new StringContent(requestBody, Encoding.UTF8, "application/x-www-form-urlencoded");
        }

        protected ResourceBase(string resourceUri, HttpMethod method, byte[] attachment)
            : this(resourceUri, method)
        {
            Content = new ByteArrayContent(attachment);
            Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
        }

        protected ResourceBase(string resourceUri, HttpMethod method)
        {
            ResourceUri = resourceUri;
            Method = method;
        }
    }
}
