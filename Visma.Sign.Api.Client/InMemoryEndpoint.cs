using System;
using Visma.Sign.Api.Client.Settings;

namespace Visma.Sign.Api.Client
{
    public sealed class InMemoryEndpoint : IEndpoint
    {
        private readonly Uri m_uri;

        public InMemoryEndpoint(Uri uri)
        {
            m_uri = uri;
        }

        public Uri Uri()
            => m_uri;
    }
}
