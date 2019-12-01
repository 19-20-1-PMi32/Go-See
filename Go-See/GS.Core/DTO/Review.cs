using System;

namespace GS.Core.DTO
{
    public class Review
    {
        public Guid Id { get; set; }

        public int Rating { get; set; }

        public string Text { get; set; }
    }
}