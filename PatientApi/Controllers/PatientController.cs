using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Core.Entities.Patients;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {

        IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        // GET: api/Patient
        [HttpGet]
        public async Task<List<Patient>> Patients()
        {
            var patientList = await _patientService.GetPatientItems();
            //  return Json(patientViewModel);

            IEnumerable<Patient> DataSource = patientList;
            //DataOperations operation = new DataOperations();
            //if (dm.Search != null && dm.Search.Count > 0)
            //{
            //    DataSource = operation.PerformSearching(DataSource, dm.Search);  //Search
            //}
            //if (dm.Sorted != null && dm.Sorted.Count > 0) //Sorting
            //{
            //    DataSource = operation.PerformSorting(DataSource, dm.Sorted);
            //}
            //if (dm.Where != null && dm.Where.Count > 0) //Filtering
            //{
            //    DataSource = operation.PerformFiltering(DataSource, dm.Where, dm.Where[0].Operator);
            //}
            //int count = DataSource.Cast<PatientViewModel>().Count();
            //if (dm.Skip != 0)
            //{
            //    DataSource = operation.PerformSkip(DataSource, dm.Skip);         //Paging
            //}
            //if (dm.Take != 0)
            //{
            //    DataSource = operation.PerformTake(DataSource, dm.Take);
            //}
            //return dm.RequiresCounts ? Json(new { result = DataSource, count = count }) : Json(DataSource);
            //try
            //{
            //    XElement root = XElement.Load(@"Svgs\test.svg");
            //    XNode firstNode = root.FirstNode;
            //    XElement root2 = XElement.Load(@"Svgs\test2.svg");
            //    root2.Add(firstNode);
            //}
            //catch (Exception ex)
            //{

            //    throw;
            //}


            return patientList;
        }

        // GET: api/Patient/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Patient
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Patient/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
