using Cabinet.Controllers;
using Cabinet.Interfaces;
using Cabinet.Models.CabinetViewModel.Informations;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Controller {

    public class InformationsControllerTests {


        [Fact]
        public async Task Informations_ReturnsViewResultWithInformationViewModel_ShouldShowInformations() {

            int testPatientId = 2;
            var mockService = new Mock<IPatientViewModelService>();
            mockService.Setup(service => service.GetPatientWithInformation(testPatientId))
                .Returns(Task.FromResult(GetInformationPatientViewModels().FirstOrDefault(p => p.Id == testPatientId)));               
            var controller = new InformationsController(mockService.Object);

            var result = await controller.Informations(testPatientId);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<InformationViewModel>(viewResult.ViewData.Model);
            Assert.Equal(testPatientId, model.Patient.Id);
            Assert.Equal("Walter", model.Patient.FirstName);
            Assert.Equal("Herpich", model.Patient.Name);
            Assert.Equal(new DateTime(2018, 8, 8, 0, 0, 0), model.Patient.DateOfBirth);
            Assert.Equal(new Age(new DateTime(2018, 8, 8)), model.Patient.Age);
        }

        private List<InformationPatientViewModel> GetInformationPatientViewModels() {
   
            var informationPatientViewModelList = new List<InformationPatientViewModel>();

            informationPatientViewModelList.Add(new InformationPatientViewModel() {
                Id = 1,
                Name = "Mustermann",
                FirstName = "Max",
                DateOfBirth = new DateTime(2018, 8, 2, 11, 0, 0),
                Age = new Age(new DateTime(2018, 8, 2, 11, 0, 0))
            });

            informationPatientViewModelList.Add(new InformationPatientViewModel() {
                Id = 2,
                Name = "Herpich",
                FirstName = "Walter",
                DateOfBirth = new DateTime(2018, 8, 8, 0, 0, 0),
                Age = new Age(new DateTime(2018, 8, 8))
            });

            informationPatientViewModelList.Add(new InformationPatientViewModel() {
                Id = 3,
                Name = "John",
                FirstName = "Rambo",
                DateOfBirth = new DateTime(2018, 8, 21, 7, 0, 0),
                Age = new Age(new DateTime(2018, 8, 21))
            });

            return informationPatientViewModelList;
        }
    }
}
