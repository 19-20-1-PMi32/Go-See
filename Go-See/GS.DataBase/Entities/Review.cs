using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GS.DataBase.Entities
{
    public class Review
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public int PlaceId { get; set; }

        public Place Place { get; set; }

        public int Rating { get; set; }

        public string Text { get; set; }
    }
}
