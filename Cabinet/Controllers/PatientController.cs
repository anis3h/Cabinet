using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cabinet.Interfaces;
using Cabinet.Models;
using Cabinet.Models.CabinetViewModel;
using Cabinet.Models.CabinetViewModel.Patient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;

namespace Cabinet.Controllers
{
    [Authorize]
    public class PatientController : Controller
    {
        IPatientViewModelService _patientViewModelService;

        public PatientController(IPatientViewModelService patientViewModelService)
        {
            _patientViewModelService = patientViewModelService;
        }

        // GET: /<controller>/
     
        public IActionResult Index()
        {
            return  View();
        }
       
        public async Task<IActionResult> Patients([FromBody]DataManagerRequest dm)
        {
            var patientViewModel = await _patientViewModelService.GetPatientItems();
            //  return Json(patientViewModel);

            IEnumerable<PatientViewModel> DataSource = patientViewModel.PatientItems;
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
            int count = DataSource.Cast<PatientViewModel>().Count();
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

        public async Task<ActionResult> Insert([FromBody]CRUDModel<PatientViewModel> value)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            // local time zone offset as TimeSpan object                


            // add the offsetTime to the datetime recieved as UTC
            value.Value.DateOfBirth = ChangeUtcDate(value.Value.DateOfBirth);

            await _patientViewModelService.Add(value.Value);
            return View("Index");

        }

        public async Task<ActionResult> Update([FromBody]CRUDModel<PatientViewModel> value)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            value.Value.DateOfBirth = ChangeUtcDate(value.Value.DateOfBirth);
            await _patientViewModelService.Update(value.Value);
            return View("Index");
        }

        public async Task<ActionResult> Delete([FromBody]CRUDModel<PatientViewModel> value)
        {
            try
            {
                if (!ModelState.IsValid) {
                    return BadRequest(ModelState);
                }

                // Value in Syncfusion = null --> Syncfusion Bug
                await _patientViewModelService.Delete((int)(Int64)value.Key);
                return View("Index");
            }
            catch(Exception exp)
            {
                Console.WriteLine(exp);
                throw (exp);
            }
        }

        [HttpGet("Error")]
        public IActionResult Error()
        {
            return View();
        }
        public DateTime ChangeUtcDate(DateTime dateTime)
        {
            var offsetTime = TimeZoneInfo.Local.GetUtcOffset(DateTime.UtcNow).Ticks;

            // convert time zone offset to minutes
            var localtime_minutes = TimeSpan.FromTicks(offsetTime).TotalMinutes;
            return dateTime.AddMinutes(localtime_minutes);
        }

    }
}
