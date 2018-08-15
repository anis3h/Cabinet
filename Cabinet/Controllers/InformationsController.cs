using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cabinet.Interfaces;
using Cabinet.Models.CabinetVIewModel;
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
            informationViewModel.Patient = await _patientViewModelService.GetPatient(id);
            return View(informationViewModel);
        }

        [HttpPost("[controller]/[action]")]
        public IActionResult Informations()
        {
            return View();
        }
    }
}