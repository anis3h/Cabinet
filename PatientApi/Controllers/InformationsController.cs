using CommunCabinet.MapperServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InformationsApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class InformationsController : ControllerBase
    {
        private readonly IPatientMapperService _patientService;

        public InformationsController(IPatientMapperService patientMapperService)
        {
            _patientService = patientMapperService;
        }

        // GET: api/Informations/information/5
        [Route("information/{id}")]
        [HttpGet]
        public async Task<IActionResult> Information(int id)
        {
            var patient = await _patientService.GetPatientWithInformation(id);
            return new JsonResult(patient);
        }

        // POST: api/Informations
        //[HttpPost]
        //public async Task<IActionResult> Informations(InformationViewModel informationViewModel)
        //{

        //    try
        //    {

        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }


        //        Enum.TryParse(Request.Form["pregnancyType"], out TypPregnancy typPregnancy);
        //        informationViewModel.Patient.Pregnancy.TypPregnancy = typPregnancy;

        //        Enum.TryParse(Request.Form["positionType"], out TypPosition typPosition);
        //        informationViewModel.Patient.Pregnancy.Position = typPosition;

        //        Enum.TryParse(Request.Form["allaitementType"], out Allaitement typAllaitement);
        //        informationViewModel.Patient.Born.Allaitement = typAllaitement;


        //        await _patientViewModelService.UpdatePatientWithInformation(informationViewModel.Patient);
        //        return RedirectToAction("Index", "Family", informationViewModel.Patient.Id);
        //    }

        //    catch (Exception exp)
        //    {
        //        throw (exp);
        //    }
        //}

        //// PUT: api/Informations/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
