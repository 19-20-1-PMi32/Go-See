using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GS.DataBase.Entities
{
    public class Place
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid CityId { get; set; }

        public City City { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public ICollection<TripNode> TripNodes { get; set; }
    }
}
