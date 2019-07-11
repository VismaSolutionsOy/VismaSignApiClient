using System;
using Visma.Sign.Api.Client.Dtos;

namespace Visma.Sign.Api.Client.UnitTests.Builders.Dtos
{
    sealed class LocationDtoBuilder
    {
        private Uri m_location = new Uri("https://vismasign.fi/");

        public LocationDtoBuilder WithLocation(string value)
            => WithLocation(new Uri(value));

        public LocationDtoBuilder WithLocation(Uri value)
        {
            m_location = value;
            return this;
        }

        public LocationDto Build()
            => new LocationDto(m_location);

        public static implicit operator LocationDto(LocationDtoBuilder b)
            => b.Build();

    }
}
