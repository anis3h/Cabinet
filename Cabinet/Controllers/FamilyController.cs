using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cabinet.Interfaces;
using Cabinet.Models.CabinetViewModel;
using Cabinet.Models.CabinetVIewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cabinet.Controllers
{
    //  [Authorize]
    public class FamilyController : Controller
    {
        IPatientViewModelService _patientViewModelService;

        public FamilyController(IPatientViewModelService patientViewModelService)
        {
            _patientViewModelService = patientViewModelService;
        }
        [HttpGet("[controller]/[action]/{id}")]
        public async Task<IActionResult> Index([FromRoute] int id)
        {
            try
            {
                var familyViewModel = new FamilyViewModel();
                familyViewModel.Patient = await _patientViewModelService.GetPatientWithFamily(id);

                return View(familyViewModel);
            }
            catch (Exception exp)
            {
                throw (exp);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(int id,  FamilyViewModel familyViewModel)
        {
            try
            {
                familyViewModel.Patient.Id = id;
                await _patientViewModelService.UpdatePatientWithFamily(familyViewModel.Patient);
                return View();
            }
           
             catch (Exception exp)
            {
                throw (exp);
            }
        }
    }
}