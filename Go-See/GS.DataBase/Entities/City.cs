using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GS.DataBase.Entities
{
    public class City
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public string IsCapital { get; set; }

        public string Description { get; set; }

        public ICollection<Place> Places { get; set; }
    }
}
