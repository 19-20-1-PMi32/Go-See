using System;
using System.Collections.Generic;

namespace GS.Core.DTO
{
    public class CityWithPlaces
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public bool IsCapital { get; set; }

        public string Description { get; set; }

        public IEnumerable<Place> Places { get; set; }
    }
}
