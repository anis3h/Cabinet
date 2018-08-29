using Core.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.Specifications.PatientSpecifications
{
    public class PatientWithConsultationsSpecification : PatientBaseSpecification
    {
        public PatientWithConsultationsSpecification(Expression<Func<Patient, bool>> criteria) : base(criteria)
        {

        }
        public override void AddIncludePatient()
        {
            // Include Tabelle 1:n Tabelle Consultations
            AddInclude(row => row.Consultations);
        }
    }
}