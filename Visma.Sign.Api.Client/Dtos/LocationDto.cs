using System;
using System.Linq;

namespace Visma.Sign.Api.Client.Dtos
{
    public sealed class LocationDto
    {   
        public Uri Location { get; }
        public string Resource
            => Location.AbsolutePath.TrimStart('/');

        public string Uuid 
            => Location
                   .AbsolutePath
                   .Split('/')
                   .FirstOrDefault(part => Guid.TryParse(part, out _)) ?? "";

        public LocationDto(Uri location)
        {
            Location = location;
        }
    }
}
