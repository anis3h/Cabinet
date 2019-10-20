using System.Collections.Generic;

namespace CommunCabinet.Dtos
{
    public class FamilyPatientDto
    {
        public PatientDto Patient { get; set; }
        public FatherDto Father { get; set; }
        public MotherDto Mother { get; set; }
        public List<SiblingDto> Siblings { get; set; } = new List<SiblingDto>();
    }
}
