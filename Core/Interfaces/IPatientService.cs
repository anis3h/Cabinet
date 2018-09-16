using Core.Entities;
using Core.Entities.Patients;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IPatientService
    {     
        Task CreatePatientAsync(Patient patient);
    }
}
