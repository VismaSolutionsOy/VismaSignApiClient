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
            if (!response.IsSuccessStatusCode)
            {
                var content = response.Content != null ? await response.Content.ReadAsStringAsync() : "";
                throw new HttpRequestException(content);
            }

            if (typeof(TResult) == typeof(LocationDto))
            {
                var location = new LocationDto(response.Headers.Location);
                return (TResult) Convert.ChangeType(location, typeof(TResult));
            }

            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResult>(responseBody);
        }
    }
}
