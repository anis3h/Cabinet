using Core.Entities.Patients;

namespace Core.Entities.Family
{
    public class PatientParent : EntityBase
    {
        // EF
        public PatientParent() { }
        public Patient Patient { get; set; }
        public Parent Parent { get; set; }
    }
}
