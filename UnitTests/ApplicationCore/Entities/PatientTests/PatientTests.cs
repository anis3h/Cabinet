using Core.Entities.Patients;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CoreUnitTests.ApplicationCore.Entities.PatientTests {

    public class PatientTests {


        [Fact]
        public void Father_NotExistingFather_ShouldNotReturnFather() {

        }

        [Fact]
        public void Father_ExistingFather_ShouldReturnFather() {

        }

        //private Patient GetPatient() {

        //    var patient = new Patient() {

        //        Id = 1,
        //        InsertDate = DateTime.Now,
        //        UpdateDate = null,
        //        Name = "Mustermann",
        //        FirstName = "Max",
        //        Tel = "0123456789",
        //        Adresse = "Musterstraße 17, 55555 Musterstadt",
        //        DateOfBirth = new DateTime(2016, 7, 13),
        //    };


        //    return patient;
        //}
    }
}
