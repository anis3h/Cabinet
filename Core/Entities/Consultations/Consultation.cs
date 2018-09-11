using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Consultations
{
    // Untersuchung
    public class Consultation : EntityBase
    {
        public DateTime Date { get; set; }
      
        // List de maladie
        // Krankheitsliste
        public List<Illness> IllnessList { get; set; }
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
        /* Vessie*/
        /* Erni*/
        /* Testicule*/
        /* Organes Génitaux*/
        /* Articulation*/
        /* Éxamen neurologique*/
        /**/
        // Synthèse (1 Phrase) Tab
        public string Synthese{ get; set; }
        // 3 lignes
        // Diagnostic Détailé
        public string Diagnostic { get; set; }
        // 5 lignes
        public string Traitement { get; set; }
        public Patient Patient { get; set; }
        public Consultation() : base() { }
    }
}
