using System;
using Visma.Sign.Api.Client.Settings;

namespace Visma.Sign.Api.Client.Examples
{
    public sealed class HardcodedEndpoint : IEndpoint
    {
        private readonly Uri m_uri;

        public HardcodedEndpoint(Uri uri)
        {
            m_uri = uri;
        }

        public Uri Uri()
            => m_uri;
    }
}
