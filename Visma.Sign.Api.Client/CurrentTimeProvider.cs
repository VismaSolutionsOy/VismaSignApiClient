using System;

namespace Visma.Sign.Api.Client
{
    public sealed class CurrentTimeProvider : ITimeProvider
    {
        public DateTime UtcNow()
            => DateTime.UtcNow;
    }
}
