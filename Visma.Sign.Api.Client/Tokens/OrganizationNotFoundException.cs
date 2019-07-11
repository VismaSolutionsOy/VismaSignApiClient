using System;

namespace Visma.Sign.Api.Client.Tokens
{
    public sealed class OrganizationNotFoundException : Exception
    {
        public string BusinessId { get; }

        public OrganizationNotFoundException(string businessId)
        {
            BusinessId = businessId;
        }
    }
}
