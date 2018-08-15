using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cabinet.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cabinet.Controllers
{
    public class FamilyController : Controller
    {
        IPatientViewModelService _patientViewModelService;

        public FamilyController(IPatientViewModelService patientViewModelService)
        {
            _patientViewModelService = patientViewModelService;
        }
        [HttpGet("[controller]/[action]/{id}")]
        public async Task<IActionResult> Family([FromRoute] int id)
        {
            var patientModel = await _patientViewModelService.GetPatient(id);
            return View(patientModel);
        }

        [HttpPost("[controller]/[action]")]
        public IActionResult Family()
        {
            return View();
        }
    }
}