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

        public int UserId { get; set; }

        public int PlaceId { get; set; }

        public int Raiting { get; set; }

        public string Text { get; set; }
    }
}
