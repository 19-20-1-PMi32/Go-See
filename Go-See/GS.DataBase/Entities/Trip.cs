using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GS.DataBase.Entities
{
    public class Trip
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int UserId { get; set; }

        public ICollection<TripNode> Locations { get; set; }
    }
}
