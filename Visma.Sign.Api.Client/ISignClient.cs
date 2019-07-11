using System.Threading.Tasks;

namespace Visma.Sign.Api.Client
{
    public interface ISignClient
    {
        Task<TResult> SendRequest<TResult>(ResourceBase resource)
            where TResult : class;
    }
}
