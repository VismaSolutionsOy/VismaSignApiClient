using System;

namespace Visma.Sign.Api.Client
{
    public interface ITimeProvider
    {
        DateTime UtcNow();
    }
}
