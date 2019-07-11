using Visma.Sign.Api.Client.Resources.V1;

namespace Visma.Sign.Api.Client.UnitTests.Builders.Resources.V1
{
    sealed class GetOrganizationBuilder
    {
        private string m_businessId = "3122704-8";

        public GetOrganizationBuilder WithBusinessId(string value)
        {
            m_businessId = value;
            return this;
        }

        public GetOrganization Build()
            => new GetOrganization(m_businessId);
    }
}
