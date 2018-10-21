using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Consultations.Examinations
{
    // Examen
    public class Examination : EntityBase
    {
        public Inspection Inspection { get; set; }
        public Skin Skin { get; set; }
        public Palpation Palpation { get; set; }
        public Articulation Articulation { get; set; }
        public Head Head { get; set; }
        public AuscultationCardioPulmonaire AuscultationCardioPulmonaire { get; set; }
        public Abdomen Abdomen { get; set; }
        public Oge Oge { get; set; }
        public Neurologique Neurologique { get; set; }
        public string Autres { get; set; }
        public Consultation Consultation { get; set; }
    }
}
