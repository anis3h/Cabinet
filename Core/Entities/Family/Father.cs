using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Core.Entities.Family
{
    public class Father : Parent
    {
        //public List<PatientParent> PatientParents { get; set; } = new List<PatientParent>();
        private int _patientParentId;
        [NotMapped]
        public int PatientParentId
        {
            get
            {
                if (_patientParentId != 0)
                    return _patientParentId;

                if (PatientParents == null || PatientParents.Count == 0)
                {
                    return 0;
                }
                return PatientParents.SingleOrDefault()?.Id ?? 0;
            }
            set
            {
                _patientParentId = value;
            }
        }
        public Father() : base() { }
    }
}
