using System;
using System.Collections.Generic;
using System.Text;

namespace Cabinet.Models.CabinetViewModel.Consultations.Examinations
{
    // Examen
    public class ExaminationViewModel
    {
        public int Id { get; set; }
        public InspectionViewModel Inspection { get; set; }
        public SkinViewModel Skin { get; set; }
        public PalpationViewModel Palpation { get; set; }
        public ArticulationViewModel Articulation { get; set; }
        public HeadViewModel Head { get; set; }
        public AuscultationCardioPulmonaireViewModel AuscultationCardioPulmonaire { get; set; }
        public AbdomenViewModel Abdomen { get; set; }
        public OgeViewModel Oge { get; set; }
        public NeurologiqueViewModel Neurologique { get; set; }
        public string Autres { get; set; }
        public ConsultationViewModel Consultation { get; set; }
    }
}
