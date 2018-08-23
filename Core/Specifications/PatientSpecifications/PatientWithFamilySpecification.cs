using Core.Entities;
using Core.Entities.Family;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Specifications.PatientSpecifications
{
    public class PatientWithFamilySpecification : PatientBaseSpecification
    {
        public PatientWithFamilySpecification(Expression<Func<Patient, bool>> criteria) : base(criteria)
        {

        }
        public override void AddIncludePatient()
        {
            // Include Tabelle 1:n Tabelle PatientParent
            AddInclude(row => row.PatientParents);
            // Include Tabelle 1:n Sibling
            AddInclude(row => (row.Siblings));
            // Include n:m Tabelle Parent
            AddInclude($"{nameof(Patient.PatientParents)}.{nameof(PatientParent.Parent)}");
        }
    }
}
