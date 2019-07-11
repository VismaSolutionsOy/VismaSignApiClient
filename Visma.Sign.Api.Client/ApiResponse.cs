using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Visma.Sign.Api.Client.Dtos;

namespace Visma.Sign.Api.Client
{
    public sealed class ApiResponse : IApiResponse
    {
        public async Task<TResult> GetResponse<TResult>(HttpRequestMessage request) where TResult : class
        {
            var client = new HttpClient();
            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(response.ReasonPhrase);
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
