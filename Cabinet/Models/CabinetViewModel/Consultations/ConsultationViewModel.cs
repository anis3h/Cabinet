using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.Models.CabinetViewModel.Consultations
{
    public class ConsultationViewModel
    {
        public int Id;
        private DateTime _date;
        public DateTime Date {
            get
            {
                return DateTime.Now;
            }
            set {
                _date = value;
            }
        }
        private DateTime _updateDate;
        public DateTime UpdateDate
        {
            get
            {
                return DateTime.Now;
            }
            set
            {
                _date = value;
            }
        }

        public string Information { get; set; }
        // List de maladie
        // Krankheitsliste
        public int? Temperature { get; set; }
        // perimitre Cranien
        // Kopfmaße
        public int? Pc { get; set; }
        // Poid
        // Gewicht
        public int? Weight { get; set; }
        // Taille
        // Grösse
        public int? Cut { get; set; }

        //Etat General text
        public string EtatGeneral { get; set; }
        // Anamnèse text
        public string Anamnèse { get; set; }
        // Examen
        public string Examen { get; set; }
        // Inspection
        public string Inspection { get; set; }

        // Peau: Pale / Ictère / Cyanose 
        public string CouleurPeau { get; set; }
        // Description Couleur Peau
        public string DescriptionCouleurPeau { get; set; }

        // Éruptions cutanées (1 phrase)
        public string EruptionsCutanees { get; set; }
        // Conjonctives: Pale / Bien coloré
        public string Conjonctives { get; set; }
        // Oedème (1 phrase)
        public string Oedeme { get; set; }

        // Oeils (1 phrase)
        public string Oeil { get; set; }
        // Lèvre (1 phrase)
        public string Levre { get; set; }
        // Gorge (1 phrase)
        public string Gorge { get; set; }
        // Adénopathie
        public string Adenopathie { get; set; }
        // Torticollis: Yes or not
        public bool? Torticollis { get; set; }
        // Direction Torticollis: Droite ou gauche
        public string TorticollisDirection { get; set; }

        /* Thorax*/
        // Rythme réspiratoire (RR) /min (0 - 90)
        public int? RythmeRespiratoire { get; set; }

        // Oscultation Pulmonaire: Eupnéique / Dyspnéique 
        public string OscultationPulmonaire { get; set; }
        // Description Oscultation Pulmonaire (Phrase 1)
        public string DescriptionOscultationPulmonaire { get; set; }

        /* Abdomène */
        // Palpation: Souple-dépréssible / Défense 
        public string PalpationAbdomene { get; set; }
        // FID: Libre / Douleureuse
        public string FID { get; set; }

        // Masse palpable: es or not
        public bool? MassePalpable { get; set; }
        // Taille en cm
        public int? TailleMassePalpableAbdomene { get; set; }

        /* Rate */
        // Palpation: palpable: yes or not 
        public bool? PalpationRate { get; set; }
        // Palpation: Taille en TD
        public int? TailleMassePalpableRate { get; set; }

        /*Foie*/
        // Palpation: palpable: yes or not 
        public bool? PalpationFoie { get; set; }
        // Palpation: Taille en TD
        public int? TailleMassePalpableFoie { get; set; }

    }
}
