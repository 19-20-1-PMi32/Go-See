using System;
using System.Collections.Generic;

namespace GS.DataBase.Entities
{
    public class City
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public bool IsCapital { get; set; }

        public string Description { get; set; }

        public ICollection<Place> Places { get; set; }
    }
}
