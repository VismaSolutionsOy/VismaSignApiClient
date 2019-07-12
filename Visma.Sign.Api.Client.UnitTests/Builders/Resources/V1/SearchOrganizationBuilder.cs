using Visma.Sign.Api.Client.Resources.V1;

namespace Visma.Sign.Api.Client.UnitTests.Builders.Resources.V1
{
    sealed class SearchOrganizationBuilder
    {
        private string m_businessId = "3122704-8";

        public SearchOrganizationBuilder WithBusinessId(string value)
        {
            m_businessId = value;
            return this;
        }

        public SearchOrganization Build()
            => new SearchOrganization(m_businessId);
    }
}
