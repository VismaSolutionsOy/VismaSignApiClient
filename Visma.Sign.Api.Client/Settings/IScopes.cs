using System.Collections.Generic;

namespace Visma.Sign.Api.Client.Settings
{
    public interface IScopes
    {
        IReadOnlyList<string> Required();
    }
}
