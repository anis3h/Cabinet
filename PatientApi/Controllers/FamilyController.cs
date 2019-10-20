using CommunCabinet.MapperServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PatientApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyController : ControllerBase
    {
        private readonly IPatientMapperService _patientMapperService;

        public FamilyController(IPatientMapperService patientMapperService)
        {
            _patientMapperService = patientMapperService;
        }

        [Route("family/{id}")]
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            try
            {
                var patient = await _patientMapperService.GetPatientWithFamily(id);
                return new JsonResult(patient);
            }
            catch (Exception exp)
            {
                throw (exp);
            }
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Index(FamilyPatientDto familyPatientDto)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        familyViewModel.Patient.Siblings = GetFromFormSiblings();
        //        await _patientViewModelService.UpdatePatientWithFamily(familyViewModel.Patient);

        //        return RedirectToAction("Index", "Patient");
        //    }
        //    catch (Exception exp)
        //    {
        //        throw (exp);
        //    }
        //}

        //private List<SiblingViewModel> GetFromFormSiblings()
        //{
        //    var siblingsJson = Request.Form["GridData"];
        //    var siblings = JsonConvert.DeserializeObject<List<SiblingViewModel>>(siblingsJson);
        //    var siblingTarget = new List<SiblingViewModel>();
        //    foreach (SiblingViewModel sibling in siblings)
        //    {
        //        if (sibling.SiblingType == "Sister")
        //        {
        //            siblingTarget.Add(new SisterViewModel(sibling));
        //        }
        //        else
        //        {
        //            siblingTarget.Add(new BrotherViewModel(sibling));
        //        }
        //    }
        //    return siblingTarget;
        //}
    }
}
