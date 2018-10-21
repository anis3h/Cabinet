using Core.Entities.Consultations;
using Core.Entities.Consultations.Examinations;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Specifications.Consultations
{
    public class ConsultationWithAllDataSpecification : ConsultationBaseSpecification
    {
        public ConsultationWithAllDataSpecification(Expression<Func<Consultation, bool>> criteria) : base(criteria)
        {
            
        }
        public override void AddIncludeConsultation()
        {
            AddInclude(consultation => consultation.Examination);
            AddInclude($"{nameof(Consultation.Examination)}.{nameof(Examination.Abdomen)}");
            AddInclude(consultation => consultation.Mensuration);
            AddInclude(consultation => consultation.Therapie);
        }
    }
}
