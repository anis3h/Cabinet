using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cabinet.Interfaces;
using Cabinet.Models.CabinetViewModel.Family;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;

namespace Cabinet.Controllers
{
    //  [Authorize]
    public class FamilyController : Controller
    {
        IPatientViewModelService _patientViewModelService;
        // 
        private List<SiblingViewModel> _siblings;

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
               // ViewBag.Data = familyViewModel.Patient.Siblings;
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
        public  async Task<IActionResult> Index(FamilyViewModel familyViewModel)
        {
            try
            {
                familyViewModel.Patient.Siblings = _siblings;
                //await _patientViewModelService.UpdatePatientWithFamily(familyViewModel.Patient);
                return RedirectToAction("Index", "Patient");
            }
           
             catch (Exception exp)
            {
                throw (exp);
            }
        }


        [HttpPost]
        [AllowAnonymous]
      //  [ValidateAntiForgeryToken]
        public void SiblingsFromGrid([FromBody] List<SiblingViewModel> data)
        {
            try
            {
                _siblings = data;
                 
            }

            catch (Exception exp)
            {
                throw (exp);
            }
        }

    }
}