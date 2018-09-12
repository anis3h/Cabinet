using Cabinet.Controllers;
using Cabinet.Interfaces;
using Cabinet.Models.CabinetViewModel.Patient;
using Cabinet.Models.Syncfusion;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Controller {


    public class PatientControllerTests {


        [Fact]
        public void Index_ReturnsAViewResult_True() {

            var mockService = new Mock<IPatientViewModelService>();
            var controller = new PatientController(mockService.Object);

            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
        }

        //[Fact]
        //public async Task Insert_AdddPatientAndReturnsIndex_WhenModelStateIsValid() {

        //    var mockService = new Mock<IPatientViewModelService>();
        //    mockService.Setup(service => service.Add(It.IsAny<PatientViewModel>()))
        //        .Returns(Task.CompletedTask)
        //        .Verifiable();
        //    var controller = new PatientController(mockService.Object);

        //    var patient = new PatientViewModel() {
        //        Id = 1,
        //        Name = "Max",
        //        FirstName = "Mustermann",
        //        DateOfBirth = DateTime.Today.AddDays(-32),
        //        Age = new Age(DateTime.Today.AddDays(-32))
        //    };

        //    var result = await controller.Insert(patient);
        //}

        //[Fact]
        //public async Task Patients_ReturnsADataManagerResult_WithAllPatients() {

        //    var mockService = new Mock<IPatientViewModelService>();
        //    mockService.Setup(service => service.GetPatientItems()).Returns(Task.FromResult(GetTestPatients()));
        //    var controller = new PatientController(mockService.Object);

        //    var result = await controller.Patients(@"{""login"":""Alex"", ""password"": ""password""}");
        //}

        private PatientIndexViewModel GetTestPatients() {

            var patientIndexViewModel = new PatientIndexViewModel();
            var patientList = new List<PatientViewModel>();

            patientList.Add(new PatientViewModel() {
                Id = 1,
                Name = "Max",
                FirstName = "Mustermann",
                DateOfBirth = DateTime.Today.AddDays(-32),
                Age = new Age(DateTime.Today.AddDays(-32))
            });

            patientList.Add(new PatientViewModel() {
                Id = 2,
                Name = "Herpich",
                FirstName = "Walter",
                DateOfBirth = DateTime.Today.AddDays(-39),
                Age = new Age(DateTime.Today.AddDays(-39))
            });

            patientList.Add(new PatientViewModel() {
                Id = 3,
                Name = "John",
                FirstName = "Rambo",
                DateOfBirth = DateTime.Today.AddDays(-24),
                Age = new Age(DateTime.Today.AddDays(-24))
            });

            var patient = new PatientViewModel() {
                Id = 1,
                Name = "Max",
                FirstName = "Mustermann",
                DateOfBirth = DateTime.Today.AddDays(-32),
                Age = new Age(DateTime.Today.AddDays(-32))
            };

            patientIndexViewModel.PatientItems = patientList;

            return patientIndexViewModel;
        }
    }
}
