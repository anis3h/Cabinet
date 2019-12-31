using System;

namespace CommunCabinet.Dtos
{
    public class SiblingDto
    {
        public Age Age { get; }
        // En bonne santé
        public bool? Health { get; set; }
        // Maladie 
        public string Information { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string SiblingType { get; set; }
    }
}
