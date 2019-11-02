using System;

namespace GS.Core.DTO
{
    public class Place
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public string Type { get; set; }
        
        public string Description { get; set; }
    }
}