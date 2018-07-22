using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public class PatientService
    {
        IAsyncRepository<Patient> patientRepository;
        public PatientService(IAsyncRepository<Patient> _patientRepository)
        {

        }

    }
}
