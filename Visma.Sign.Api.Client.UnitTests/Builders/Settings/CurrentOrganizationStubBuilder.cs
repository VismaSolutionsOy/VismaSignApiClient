using NSubstitute;
using Visma.Sign.Api.Client.Settings;

namespace Visma.Sign.Api.Client.UnitTests.Builders.Settings
{
    sealed class CurrentOrganizationStubBuilder
    {
        private string m_businessId = "1234567-1";

        public CurrentOrganizationStubBuilder WithBusinessId(string value)
        {
            m_businessId = value;
            return this;
        }

        public ICurrentOrganization Build()
        {
            var stub = Substitute.For<ICurrentOrganization>();
            stub.BusinessId().Returns(m_businessId);

            return stub;
        }
    }
}
