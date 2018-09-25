using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cabinet.Interfaces;
using Cabinet.Models.CabinetViewModel.Family;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Syncfusion.EJ2.Base;

namespace Cabinet.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> Index(FamilyViewModel familyViewModel)
        {
            try {
                if (!ModelState.IsValid) {
                    return BadRequest(ModelState);
                }

                familyViewModel.Patient.Siblings = GetFromFormSiblings();
                await _patientViewModelService.UpdatePatientWithFamily(familyViewModel.Patient);

                return RedirectToAction("Index", "Patient");
            }           
             catch (Exception exp)
            {
                throw (exp);
            }
        }

        private List<SiblingViewModel> GetFromFormSiblings()
        {
            var siblingsJson = Request.Form["GridData"];
            var siblings = JsonConvert.DeserializeObject<List<SiblingViewModel>>(siblingsJson);
            var siblingTarget = new List<SiblingViewModel>();
            foreach (SiblingViewModel sibling in siblings)
            {
                if (sibling.SiblingType == "Sister")
                {
                    siblingTarget.Add(new SisterViewModel(sibling));
                }
                else
                {
                    siblingTarget.Add(new BrotherViewModel(sibling));
                }
            }
            return siblingTarget;
        }

        // [HttpPost]
        // [AllowAnonymous]
        // //  [ValidateAntiForgeryToken]
        //// public void SiblingsFromGrid(FamilyViewModel familyViewModel, [FromBody] List<SiblingViewModel> data)
        // public void SiblingsFromGrid([FromBody] string test)
        // {
        //     try
        //     {




        //     }

        //     catch (Exception exp)
        //     {
        //         throw (exp);
        //     }
        // }

    }
}