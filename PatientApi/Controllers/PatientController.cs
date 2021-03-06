﻿using CommunCabinet.Dtos;
using CommunCabinet.MapperServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularTest.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class PatientController : Controller
    {
        IPatientMapperService _patientService;

        public PatientController(IPatientMapperService patientService)
        {
            _patientService = patientService;
        }

        // GET: api/Patient
        [HttpPost]
        public async Task<IActionResult> Patients([FromBody]DataManagerRequest dm)
        {
            try
            {
                var patientViewModel = await _patientService.GetPatientItems();

                IEnumerable<PatientDto> DataSource = patientViewModel;
                DataOperations operation = new DataOperations();
                if (dm.Search != null && dm.Search.Count > 0)
                {
                    var test = new List<string>();
                    foreach (var item in dm.Search)
                    {
                        if (item.Fields != null && item.Fields.Count() > 0)
                        {
                            foreach (var field in item.Fields)
                            {
                                test.Add(field.First().ToString().ToUpper() + field.Substring(1));
                            }
                            item.Fields = test;
                        }
                    }
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
            catch (Exception ex)
            {
                throw;
            }
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
            return Ok();
        }

        // PUT: api/Patient/5
        [HttpPost()]
        public async Task<ActionResult> Update([FromBody]CRUDModel<PatientDto> value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _patientService.Update(value.Value);
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpPost()]
        public async Task<ActionResult> Delete([FromBody]CRUDModel<PatientDto> value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                // Value in Syncfusion = null --> Syncfusion Bug
                await _patientService.Delete((int)(Int64)value.Key);
                return Ok();
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
                throw (exp);
            }
        }
    }

    //[ApiVersion("1.0")]
    //[ApiController]
    //[Route("api/v{version:apiVersion}/[controller]")]
    //public class HelloWorldController : Controller
    //{
    //    [HttpGet]
    //    [Route("")]
    //    public string Get() => "Hello world!";
    //}

    //[ApiVersion("2.0")]
    //[ApiVersion("3.0")]
    //[ApiController]
    //[Route("api/v{version:apiVersion}/helloworld")]
    //public class HelloWorld2Controller : Controller
    //{
    //    [HttpGet]
    //    [Route("{test}")]
    //    public string Get(int test) => "Hello world v2!";

    //    [HttpGet, MapToApiVersion("3.0")]
    //    [Route("")]
    //    public string GetV3() => "Hello world v3!";
    //}
}
