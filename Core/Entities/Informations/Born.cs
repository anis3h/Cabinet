using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Informations
{
    public class Born : EntityBase
    {
        // Poids de naissance
        public int BirthWeight { get; set; }
        // Cris immediat?
        public bool Cry { get; set; }
        // 0 - 10 Apgar 1 mn
        public int Apgar1mn { get; set; }
        // 0 - 10 Apgar 5 mn
        public int Apgar5mn { get; set; }
        // maternelle exclusif/ mixte / Artificiel
        public string Allaitement { get; set; }
        // Remarque
        public string RemarqueAllaitement { get; set; }
    }
}
