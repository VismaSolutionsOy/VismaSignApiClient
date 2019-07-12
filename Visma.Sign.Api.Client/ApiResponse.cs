using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Visma.Sign.Api.Client.Dtos;

namespace Visma.Sign.Api.Client
{
    public sealed class ApiResponse : IApiResponse
    {
        private readonly IHttpClient m_client;

        public ApiResponse(IHttpClient client)
        {
            m_client = client;
        }

        public async Task<TResult> GetResponse<TResult>(HttpRequestMessage request) where TResult : class
        {
            var response = await m_client.SendAsync(request);
            if (typeof(TResult) == typeof(HttpStatusCodeDto))
            {
                return HttpStatusCodeResponse<TResult>(response);
            }

            if (!response.IsSuccessStatusCode)
            {
                var content = response.Content != null ? await response.Content.ReadAsStringAsync() : "";
                throw new HttpRequestException(content);
            }

            if (typeof(TResult) == typeof(LocationDto))
            {
                return LocationResponse<TResult>(response);
            }

            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResult>(responseBody);
        }

        private static TResult LocationResponse<TResult>(HttpResponseMessage response) where TResult : class
        {
            var location = new LocationDto(response.Headers.Location);
            return (TResult) Convert.ChangeType(location, typeof(TResult));
        }

        private static TResult HttpStatusCodeResponse<TResult>(HttpResponseMessage response) where TResult : class
        {
            var status = new HttpStatusCodeDto(response.StatusCode);
            return (TResult) Convert.ChangeType(status, typeof(TResult));
        }
    }
}
