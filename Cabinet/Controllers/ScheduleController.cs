using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cabinet.Interfaces;
using Cabinet.Models.CabinetViewModel.Schedule;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;


namespace Cabinet.Controllers
{
    public class ScheduleController : Controller {

        private readonly IScheduleViewModelService _scheduleViewModelService;


        public ScheduleController(IScheduleViewModelService scheduleViewModelService) {

            _scheduleViewModelService = scheduleViewModelService;
        }


        public IActionResult Index() {
            return View();
        }

        public async Task<IActionResult> GetData() {

            var scheduleViewModel = await _scheduleViewModelService.GetAll();

            return Json(new { result = scheduleViewModel.AppointmentViewModelList });
        }

        public async Task<IActionResult> Insert([FromBody]CRUDModel<AppointmentViewModel> value) {

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            await _scheduleViewModelService.Add(value.Value);
            return View("Index");
        }

        public async Task<IActionResult> UpdateData([FromBody]CRUDModel<AppointmentViewModel> value) {
            // this block of code will execute while inserting the appointments

            string test;
            return View("Index");
        }

        //public async Task<IActionResult> Update([FromBody]CRUDModel<PatientViewModel> value) {
        //    if (!ModelState.IsValid) {
        //        return BadRequest(ModelState);
        //    }

        //    await _patientViewModelService.Update(value.Value);
        //    return View("Index");
        //}

        //public async Task<IActionResult> Delete([FromBody]CRUDModel<PatientViewModel> value) {
        //    try {
        //        if (!ModelState.IsValid) {
        //            return BadRequest(ModelState);
        //        }

        //        // Value in Syncfusion = null --> Syncfusion Bug
        //        await _patientViewModelService.Delete((int)(Int64)value.Key);
        //        return View("Index");
        //    }
        //    catch (Exception exp) {
        //        Console.WriteLine(exp);
        //        throw (exp);
        //    }
        //}
    
    }
}