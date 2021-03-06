﻿using System;

namespace GS.DataBase.Entities
{
    public class Review
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }

        public Guid PlaceId { get; set; }

        public Place Place { get; set; }

        public int Rating { get; set; }

        public string Text { get; set; }
    }
}
