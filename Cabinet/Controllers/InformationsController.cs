using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cabinet.Interfaces;
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
            var patientViewModel = await _patientViewModelService.GetPatient(id);
            return View(patientViewModel);
        }

        [HttpPost("[controller]/[action]")]
        public IActionResult Informations()
        {
            return View();
        }
    }
}