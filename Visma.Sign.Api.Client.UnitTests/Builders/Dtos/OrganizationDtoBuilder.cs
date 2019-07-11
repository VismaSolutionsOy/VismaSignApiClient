using Visma.Sign.Api.Client.Dtos;

namespace Visma.Sign.Api.Client.UnitTests.Builders.Dtos
{
    sealed class OrganizationDtoBuilder
    {
        private string m_uuid = "7d2ad74a-8672-414c-b570-f261f638b622";
        private string m_businessId = "1234567-1";
        private string m_name = "Testi Oy";

        public OrganizationDtoBuilder WithUuid(string value)
        {
            m_uuid = value;
            return this;
        }

        public OrganizationDtoBuilder WithBusinessId(string value)
        {
            m_businessId = value;
            return this;
        }

        public OrganizationDtoBuilder WithName(string value)
        {
            m_name = value;
            return this;
        }

        public OrganizationDto Build()
            => new OrganizationDto()
            {
                business_id = m_businessId,
                name = m_name,
                uuid = m_uuid
            };

        public static implicit operator OrganizationDto(OrganizationDtoBuilder b)
            => b.Build();
    }
}
