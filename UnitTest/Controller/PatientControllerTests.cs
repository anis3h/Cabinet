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
using Syncfusion.EJ2.Base;

namespace ControllerUnitTests.Controller {


    public class PatientControllerTests {


        [Fact]
        public void Index_ReturnsAViewResult_ShouldShowPatientIndex() {

            // Arrange
            var mockService = new Mock<IPatientViewModelService>();
            var controller = new PatientController(mockService.Object);

            // Act
            var result = controller.Index();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task Insert_ReturnsBadRequestResult_WhenModelStateIsInvalid() {

            var mockService = new Mock<IPatientViewModelService>();
            mockService.Setup(service => service.Add(It.IsAny<PatientViewModel>()))
                .Returns(Task.CompletedTask)
                .Verifiable();
            var controller = new PatientController(mockService.Object);
            controller.ModelState.AddModelError("Name", "Error Massage");

            var patientViewModel = new PatientViewModel() {
                Id = 99,
                Name = "Test",
                FirstName = "Mustermann",
                DateOfBirth = DateTime.Today.AddDays(-32),
                Age = new Age(DateTime.Today.AddDays(-32))
            };

            var crudModel = new Syncfusion.EJ2.Base.CRUDModel<PatientViewModel>();
            crudModel.Value = patientViewModel;

            var result = await controller.Insert(crudModel);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Insert_AdddPatientAndReturnsIndex_WhenModelStateIsValid() {

            var mockService = new Mock<IPatientViewModelService>();
            mockService.Setup(service => service.Add(It.IsAny<PatientViewModel>()))
                .Returns(Task.CompletedTask)
                .Verifiable();
            var controller = new PatientController(mockService.Object);

            var patientViewModel = new PatientViewModel() {
                Id = 1,
                Name = "Max",
                FirstName = "Mustermann",
                DateOfBirth = DateTime.Today.AddDays(-32),
                Age = new Age(DateTime.Today.AddDays(-32))
            };

            var crudModel = new Syncfusion.EJ2.Base.CRUDModel<PatientViewModel>();
            crudModel.Value = patientViewModel;

            var result = await controller.Insert(crudModel);

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Index", viewResult.ViewName);
        }

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
