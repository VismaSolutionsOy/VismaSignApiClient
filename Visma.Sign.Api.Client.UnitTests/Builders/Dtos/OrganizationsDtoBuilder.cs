using System.Collections.Generic;
using Visma.Sign.Api.Client.Dtos;

namespace Visma.Sign.Api.Client.UnitTests.Builders.Dtos
{
    sealed class OrganizationsDtoBuilder
    {
        private List<OrganizationDto> m_organizations = new List<OrganizationDto>();

        public OrganizationsDtoBuilder WithOrganizations(params OrganizationDto[] value)
        {
            m_organizations.AddRange(value);
            return this;
        }

        public OrganizationsDto Build()
            => new OrganizationsDto()
            {
                organizations = new List<OrganizationDto>(m_organizations)
            };

        public static implicit operator OrganizationsDto(OrganizationsDtoBuilder b)
            => b.Build();
    }
}
