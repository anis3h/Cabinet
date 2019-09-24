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
using Syncfusion.EJ2.Base;
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
        [HttpGet]
        public async Task<IActionResult> Patients()
        {
            var patientViewModel = await _patientService.GetPatientItems();
            //  return Json(patientViewModel);

            //IEnumerable<PatientDto> DataSource = patientViewModel.Take(10);
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
            //int count = DataSource.Cast<PatientDto>().Count();
            //if (dm.Skip != 0)
            //{
            //    DataSource = operation.PerformSkip(DataSource, dm.Skip);         //Paging
            //}
            //if (dm.Take != 0)
            //{
            //    DataSource = operation.PerformTake(DataSource, dm.Take);
            //}
            //return dm.RequiresCounts ? Json(new { result = DataSource, count = count }) : Json(DataSource);
            return Ok(patientViewModel);
        }

        // GET: api/Patient/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        //// POST: api/Patient
        //[HttpPost]
        //public Task<ActionResult> Post([FromBody]CRUDModel<PatientViewModel> value)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    await _patientViewModelService.Add(value.Value);
        //    return View("Index");
        //}

        //// PUT: api/Patient/5
        //[HttpPut("{id}")]
        //public Task<ActionResult> Put([FromBody]CRUDModel<PatientViewModel> value)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    await _patientViewModelService.Update(value.Value);
        //    return View("Index");
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        // Value in Syncfusion = null --> Syncfusion Bug
        //        await _patientViewModelService.Delete((int)(Int64)value.Key);
        //        return View("Index");
        //    }
        //    catch (Exception exp)
        //    {
        //        Console.WriteLine(exp);
        //        throw (exp);
        //    }
        //}
    }
}
