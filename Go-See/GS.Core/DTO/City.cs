using System.Collections.Generic;

namespace GS.Core.DTO
{
    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public bool IsCapital { get; set; }

        public string Description { get; set; }
    }
}