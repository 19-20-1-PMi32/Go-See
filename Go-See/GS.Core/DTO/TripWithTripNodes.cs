using System;
using System.Collections.Generic;

namespace GS.Core.DTO
{
    public class TripWithTripNodes
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid UserId { get; set; }

        public IEnumerable<TripNode> TripNodes { get; set; }
    }
}
