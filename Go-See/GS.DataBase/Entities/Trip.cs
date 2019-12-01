using System;
using System.Collections.Generic;

namespace GS.DataBase.Entities
{
    public class Trip
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }

        public ICollection<TripNode> TripNodes { get; set; }
    }
}
