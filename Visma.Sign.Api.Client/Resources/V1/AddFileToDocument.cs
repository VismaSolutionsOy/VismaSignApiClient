using System.Net.Http;
using System.Web;
using Visma.Sign.Api.Client.Dtos;

namespace Visma.Sign.Api.Client.Resources.V1
{
    public sealed class AddFileToDocument : ResourceBase
    {
        public AddFileToDocument(LocationDto location, string fileName, byte[] attachment)
            : base($"{location.Resource}/files?filename={HttpUtility.UrlEncode(fileName)}", HttpMethod.Post, attachment)
        {
        }
    }
}