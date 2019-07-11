using System.Collections.Generic;
using NSubstitute;
using Visma.Sign.Api.Client.Settings;

namespace Visma.Sign.Api.Client.UnitTests.Builders.Settings
{
    sealed class ScopesStubBuilder
    {
        private List<string> m_required = new List<string>();

        public ScopesStubBuilder WithRequired(params string[] value)
        {
            m_required.AddRange(value);
            return this;
        }

        public IScopes Build()
        {
            var stub = Substitute.For<IScopes>();
            stub.Required().Returns(m_required);

            return stub;
        }
    }
}
