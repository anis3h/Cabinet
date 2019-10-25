using System;

namespace CommunCabinet.Dtos
{
    public class PatientDto
    {
        //[JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }
        //[JsonProperty(PropertyName = "fileNumber")]
        public int FileNumber { get; set; }
        //[JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        //[JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }
        //[JsonProperty(PropertyName = "dateOfBirth")]
        public DateTime DateOfBirth { get; set; }
        //[JsonProperty(PropertyName = "adresse")]
        public string Adresse { get; set; }
    }
}
