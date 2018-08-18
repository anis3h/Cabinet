using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cabinet.Interfaces;
using Cabinet.Models.CabinetViewModel;
using Cabinet.Models.CabinetVIewModel;
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
            try
            {
                var familyViewModel = new FamilyViewModel();
                familyViewModel.Patient = await _patientViewModelService.GetPatientWithFamily(id);

                return View(familyViewModel);
            }
            catch(Exception exp)
            {
                throw (exp);
            }
        }

        [HttpPost("[controller]/[action]")]
        public IActionResult Family()
        {
            return View();
        }
    }
}