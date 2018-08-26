using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cabinet.Interfaces;
using Cabinet.Models.CabinetViewModel;
using Cabinet.Models.CabinetViewModel.Informations;
using Microsoft.AspNetCore.Mvc;

namespace Cabinet.Controllers
{
    public class InformationsController : Controller
    {
        IPatientViewModelService _patientViewModelService;

        public InformationsController(IPatientViewModelService patientViewModelService)
        {
            _patientViewModelService = patientViewModelService;
        }

        [HttpGet("[controller]/[action]/{id}")]
        public async Task<IActionResult> Informations([FromRoute] int id)
        {
            var informationViewModel = new InformationViewModel();
            informationViewModel.Patient = await _patientViewModelService.GetPatientWithInformation(id);
            return View(informationViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Informations(InformationViewModel informationViewModel) {

            try {
                await _patientViewModelService.UpdatePatientWithInformation(informationViewModel.Patient);
                return RedirectToAction("Index", "Patient");
            }

            catch (Exception exp) {
                throw (exp);
            }
        }
    }
}