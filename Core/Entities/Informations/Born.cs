using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Informations
{
    public class Born : EntityBase
    {
        // Poids de naissance
        // Gewicht bei der Geburt
        public int BirthWeight { get; set; }
        // Cris immediat?
        // Sofort geschriehen
        public bool Cry { get; set; }
        // 0 - 10 Apgar 1 mn
        public int Apgar1mn { get; set; }
        // 0 - 10 Apgar 5 mn
        public int Apgar5mn { get; set; }
        // maternelle exclusif/ mixte / Artificiel
        public Allaitement Allaitement { get; set; }
        // Remarque
        public string RemarqueAllaitement { get; set; }
       
    }
}

public enum Allaitement {

    Maternelle,
    Exclusif,
    Mixte,
    Artificiel
}
