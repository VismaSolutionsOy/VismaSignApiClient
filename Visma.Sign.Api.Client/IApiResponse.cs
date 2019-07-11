using System.Net.Http;
using System.Threading.Tasks;

namespace Visma.Sign.Api.Client
{
    public interface IApiResponse
    {
        Task<TResult> GetResponse<TResult>(HttpRequestMessage value) where TResult : class;
    }
}
