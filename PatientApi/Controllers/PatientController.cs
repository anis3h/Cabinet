using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using CommunCabinet.Dtos;
using CommunCabinet.MapperServices.Interfaces;
using Core.Entities.Patients;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Syncfusion.EJ2;
using Syncfusion.EJ2.Base;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNet.OData.Routing;
//using Syncfusion.EJ2.Base;

namespace AngularTest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PatientController : Controller
    {
        IPatientMapperService _patientService;

        public PatientController(IPatientMapperService patientService)
        {
            _patientService = patientService;
        }

        // GET: api/Patient
        
        public async Task<IActionResult> Patients([FromBody]DataManagerRequest dm)
        {
            var patientViewModel = await _patientService.GetPatientItems();

            IEnumerable<PatientDto> DataSource = patientViewModel;
            DataOperations operation = new DataOperations();
            if (dm.Search != null && dm.Search.Count > 0)
            {
                DataSource = operation.PerformSearching(DataSource, dm.Search);  //Search
            }
            if (dm.Sorted != null && dm.Sorted.Count > 0) //Sorting
            {
                DataSource = operation.PerformSorting(DataSource, dm.Sorted);
            }
            if (dm.Where != null && dm.Where.Count > 0) //Filtering
            {
                DataSource = operation.PerformFiltering(DataSource, dm.Where, dm.Where[0].Operator);
            }
            int count = DataSource.Cast<PatientDto>().Count();
            if (dm.Skip != 0)
            {
                DataSource = operation.PerformSkip(DataSource, dm.Skip);         //Paging
            }
            if (dm.Take != 0)
            {
                DataSource = operation.PerformTake(DataSource, dm.Take);
            }
            return dm.RequiresCounts ? Json(new { result = DataSource, count = count }) : Json(DataSource);
        }

        // GET: api/Patient/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Patient
        [HttpPost]
        public async Task<ActionResult> Insert([FromBody]CRUDModel<PatientDto> value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _patientService.Add(value.Value);
            return View("Index");
        }

        // PUT: api/Patient/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromBody]CRUDModel<PatientDto> value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _patientService.Update(value.Value);
            return View("Index");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Value in Syncfusion = null --> Syncfusion Bug
                await _patientService.Delete(id);
                return View("Index");
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
                throw (exp);
            }
        }
    }
}
