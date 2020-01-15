using System.Collections.Generic;

namespace CommunCabinet.Dtos
{
    public class FamilyPatientDto
    {
        public PatientDto Patient { get; set; }
        private FatherDto _fatherDto;
        private MotherDto _motherDto;
        public FatherDto Father
        {
            get
            {
                //if (_fatherDto == null) return new FatherDto();
                return _fatherDto;
            }
            set
            {
                _fatherDto = value;
            }
        }
        public MotherDto Mother
        {
            get
            {
                //if (_motherDto == null) return new MotherDto();
                return _motherDto;
            }
            set
            {
                _motherDto = value;
            }
        }
        public List<SiblingDto> Siblings { get; set; } = new List<SiblingDto>();
    }
}
