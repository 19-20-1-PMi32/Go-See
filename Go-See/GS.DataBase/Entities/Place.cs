using System;
using System.Collections.Generic;

namespace GS.DataBase.Entities
{
    public class Place
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid? CityId { get; set; }

        public City City { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public ICollection<TripNode> TripNodes { get; set; }
    }
}
