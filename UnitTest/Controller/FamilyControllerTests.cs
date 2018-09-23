using Cabinet.Controllers;
using Cabinet.Interfaces;
using Cabinet.Models.CabinetViewModel.Family;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControllerUnitTests.Controller {


    public class FamilyControllerTests {


        [Fact]
        public async Task Index_ReturnsViewResultWithFamilyViewModel_ShouldShowFamily() {

            // Arrange
            int testPatientId = 2;
            var mockService = new Mock<IPatientViewModelService>();
            mockService.Setup(service => service.GetPatientWithFamily(testPatientId))
                .Returns(Task.FromResult(It.IsAny<FamilyPatientViewModel>()));
            var controller = new FamilyController(mockService.Object);

            // Act
            var result = await controller.Index(testPatientId);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<FamilyViewModel>(viewResult.ViewData.Model);
        }


        [Fact]
        public async Task IndexPOST_ReturnsBadRequestResult_WhenModelStateIsInvalid() {

            var mockService = new Mock<IPatientViewModelService>();
            mockService.Setup(service => service.UpdatePatientWithFamily(It.IsAny<FamilyPatientViewModel>()));
            var controller = new FamilyController(mockService.Object);
            controller.ModelState.AddModelError("Name", "Required");
            var familyViewModel = new FamilyViewModel();

            var result = await controller.Index(familyViewModel);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }


        //[Fact]
        //public async Task IndexPOST_ReturnsARedirectAndUpdatePatientFamily_WhenModelStateIsValid() {

        //    var mockService = new Mock<IPatientViewModelService>();
        //    mockService.Setup(service => service.UpdatePatientWithFamily(It.IsAny<FamilyPatientViewModel>()))
        //        .Returns(Task.CompletedTask)
        //        .Verifiable();
        //    var controller = new FamilyController(mockService.Object);
        //    // Give the controller an HttpContext.
        //    controller.ControllerContext.HttpContext = new DefaultHttpContext();
        //    // Request is not null anymore.
        //    controller.Request.Form = GetRequestFormCollection();
        //    var familyViewModel = GetIFamilyViewModel();

        //    var result = await controller.Index(familyViewModel);

        //    var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
        //    Assert.Equal("Index", redirectToActionResult.ActionName);
        //    mockService.Verify();
        //}


        //private FormCollection GetRequestFormCollection() {

        //    var dic = new Dictionary<string, StringValues>();
        //    dic.Add("GridData", "Sister");
        //    return new FormCollection(dic);
        //}

        //private FamilyViewModel GetIFamilyViewModel() {

        //    var familyViewModel = new FamilyViewModel {


        //        Patient = new FamilyPatientViewModel {
        //            Id = 4,
        //            Name = "Vier",
        //            FirstName = "Person",
        //            DateOfBirth = new DateTime(2018, 8, 1, 7, 0, 0),
        //            Age = new Age(new DateTime(2018, 8, 1)),
        //            Siblings = new List<SiblingViewModel>()

        //        }
        //    };

        //    return familyViewModel;
        //}
    }
}
