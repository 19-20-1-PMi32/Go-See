using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GS.DataBase.Entities
{
    public class TripNode
    {
        public int Id { get; set; }

        public int TripId { get; set; }

        public int PlaceId { get; set; }

        public int SequenceNumber { get; set; }
    }
}
