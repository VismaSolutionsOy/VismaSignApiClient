using Visma.Sign.Api.Client.Resources.V1;

namespace Visma.Sign.Api.Client.UnitTests.Builders.Resources.V1
{
    sealed class GetOrganizationBuilder
    {
        private string m_uuid = "1234";

        public GetOrganizationBuilder WithOrganizationUuid(string value)
        {
            m_uuid = value;
            return this;
        }

        public GetOrganization Build()
            => new GetOrganization(m_uuid);

        public static implicit operator GetOrganization(GetOrganizationBuilder b)
            => b.Build();

    }
}
