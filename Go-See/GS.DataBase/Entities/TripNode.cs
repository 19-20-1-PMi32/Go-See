using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GS.DataBase.Entities
{
    public class TripNode
    {
        public Guid Id { get; set; }

        public Guid TripId { get; set; }

        public Trip Trip { get; set; }

        public Guid PlaceId { get; set; }

        public Place Place { get; set; }

        public int SequenceNumber { get; set; }
    }
}
