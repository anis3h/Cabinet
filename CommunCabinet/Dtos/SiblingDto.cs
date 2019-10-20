using System;

namespace CommunCabinet.Dtos
{
    public class SiblingDto
    {
        public int? Id { get; set; }
        public Age Age;
        // En bonne santé
        public bool? Health { get; set; }
        // Maladie 
        public string Information { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public virtual string SiblingType { get; set; }
        public virtual string Type { get; set; }
        public string Fraternity { get; set; }
    }
}
