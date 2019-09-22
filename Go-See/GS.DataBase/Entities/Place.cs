using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GS.DataBase.Entities
{
    public class Place
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? CityId { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
