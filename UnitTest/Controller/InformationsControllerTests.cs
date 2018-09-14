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
using IPatientViewModelService = Cabinet.Interfaces.IPatientViewModelService;

namespace ControllerUnitTests.Controller {

    public class InformationsControllerTests {


        [Fact]
        public async Task InformationsGET_ReturnsViewResultWithInformationViewModel_ShouldShowInformations() {

            // Arrange
            int testPatientId = 2;
            var mockService = new Mock<IPatientViewModelService>();
            mockService.Setup(service => service.GetPatientWithInformation(testPatientId))
                .Returns(Task.FromResult(GetInformationPatientViewModels().FirstOrDefault(p => p.Id == testPatientId)));
            var controller = new InformationsController(mockService.Object);

            // Act
            var result = await controller.Informations(testPatientId);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<InformationViewModel>(viewResult.ViewData.Model);
            Assert.Equal(testPatientId, model.Patient.Id);
            Assert.Equal("James", model.Patient.FirstName);
            Assert.Equal("Bond", model.Patient.Name);
            Assert.Equal(new DateTime(2018, 8, 8, 0, 0, 0), model.Patient.DateOfBirth);
            //Assert.Equal(new Age(new DateTime(2018, 8, 8)), model.Patient.Age);
        }


        [Fact]
        public async Task InformationsPOST_ReturnsBadRequestResult_WhenModelStateIsInvalid() {

            var mockService = new Mock<IPatientViewModelService>();
            mockService.Setup(service => service.UpdatePatientWithInformation(GetTestPatient().Patient));
            var controller = new InformationsController(mockService.Object);
            controller.ModelState.AddModelError("Name", "Required");
            var newInformationViewModel = new InformationViewModel();

            var result = await controller.Informations(newInformationViewModel);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }


        [Fact]
        public async Task InformationsPOST_ReturnsARedirectAndUpdatePatient_WhenModelStateIsValid() {

            var mockService = new Mock<IPatientViewModelService>();
            //mockService.Setup(service => service.UpdatePatientWithInformation(It.IsAny<InformationPatientViewModel>()));
            mockService.Setup(service => service.UpdatePatientWithInformation(GetTestPatient().Patient))
                .Returns(Task.CompletedTask)
                .Verifiable();
            var controller = new InformationsController(mockService.Object);
            var informationViewModel = GetTestPatient();

            var result = await controller.Informations(informationViewModel);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mockService.Verify();
        }


        private List<InformationPatientViewModel> GetInformationPatientViewModels() {

            var informationPatientViewModelList = new List<InformationPatientViewModel>();

            informationPatientViewModelList.Add(new InformationPatientViewModel {
                Id = 1,
                Name = "Mustermann",
                FirstName = "Max",
                DateOfBirth = new DateTime(2018, 8, 2, 11, 0, 0),
                Age = new Age(new DateTime(2018, 8, 2, 11, 0, 0))
            });

            informationPatientViewModelList.Add(new InformationPatientViewModel {
                Id = 2,
                Name = "Bond",
                FirstName = "James",
                DateOfBirth = new DateTime(2018, 8, 8, 0, 0, 0),
                Age = new Age(new DateTime(2018, 8, 8))
            });

            informationPatientViewModelList.Add(new InformationPatientViewModel {
                Id = 3,
                Name = "John",
                FirstName = "Rambo",
                DateOfBirth = new DateTime(2018, 8, 21, 7, 0, 0),
                Age = new Age(new DateTime(2018, 8, 21))
            });

            return informationPatientViewModelList;
        }

        private InformationViewModel GetTestPatient() {

            var informationViewModel = new InformationViewModel {


                Patient = new InformationPatientViewModel {
                    Id = 4,
                    Name = "Vier",
                    FirstName = "Person",
                    DateOfBirth = new DateTime(2018, 8, 1, 7, 0, 0),
                    Age = new Age(new DateTime(2018, 8, 1)),
                    Adresse = "Musterstraße",
                    FileNumber = 999,
                    Pregnancy = new PregnancyViewModel {
                        TypPregnancy = TypPregnancy.Prématurité,
                        Month = 5,
                        Week = 13,
                        Day = 7,
                        Position = TypPosition.Siège
                    },
                    Born = new BornViewModel {
                        BirthWeight = 3,
                        Cry = true,
                        Apgar1mn = 1,
                        Apgar5mn = 5,
                        Allaitement = Allaitement.Exclusif,
                        RemarqueAllaitement = "RemarqueAllaitement"
                    }
                }
            };

            return informationViewModel;
        }
    }
}
