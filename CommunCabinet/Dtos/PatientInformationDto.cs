using System;
using System.Collections.Generic;
using System.Text;

namespace CommunCabinet.Dtos
{
    public class PatientInformationDto
    {
        public string Tel { get; set; }
        public PatientDto Patient { get; set; }
        public PregnancyDto Pregnancy { get; set; }
        public BornDto Born { get; set; }
    }
}
