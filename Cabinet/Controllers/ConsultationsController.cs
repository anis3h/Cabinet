using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cabinet.Interfaces;
using Cabinet.Models.CabinetViewModel.Consultations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cabinet.Controllers
{
    public class ConsultationsController : Controller
    {
        IPatientViewModelService _patientViewModelService;
        IConsultationViewModelService _consultationViewModelService;

        public ConsultationsController(IPatientViewModelService patientViewModelService, IConsultationViewModelService consultationViewModelService)
        {
            _patientViewModelService = patientViewModelService;
            _consultationViewModelService = consultationViewModelService;
        }
        [HttpGet("[controller]/[action]/{id}")]
        public async Task<IActionResult> Index([FromRoute] int id)
        {
            try
            {
                var consultationsViewModel = new ConsultationsViewModel();
                consultationsViewModel.Patient = await _patientViewModelService.GetPatientWithConsultations(id);
             //   ViewBag.Data = familyViewModel.Patient.Siblings;
                return View(consultationsViewModel);
            }
            catch (Exception exp)
            {
                throw (exp);
            }
        }

        [HttpGet("[controller]/[action]")]
        public IActionResult Consultation()
        {
            try
            {
                return View();
            }
            catch (Exception exp)
            {
                throw (exp);
            }
        }

        [HttpGet("[controller]/[action]/{id}")]
        public async Task<IActionResult> Consultation([FromRoute] int id)
        {
            try
            {
                var consultationViewModel = new ConsultationViewModel();
                consultationViewModel = await _consultationViewModelService.GetConsultation(id);
                return View(consultationViewModel);
            }
            catch (Exception exp)
            {
                throw (exp);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Consultation(ConsultationViewModel consultationViewModel)
        {
            try
            {
                await _consultationViewModelService.Update(consultationViewModel);
                return RedirectToAction("Index", "Consultations");
            }

            catch (Exception exp)
            {
                throw (exp);
            }
        }

        //[HttpPost("[controller]/[action]/{id}")]
        //public async Task<IActionResult> Consultations(int id, [FromBody]DataManagerRequest dm)
        //{
        //    var patientViewModel = await _patientViewModelService.GetPatientWithConsultations(id); 
        //    //  return Json(patientViewModel);

        //    IEnumerable<ConsultationViewModel> DataSource = patientViewModel.Consultations;
        //    DataOperations operation = new DataOperations();
        //    if (dm.Search != null && dm.Search.Count > 0)
        //    {
        //        DataSource = operation.PerformSearching(DataSource, dm.Search);  //Search
        //    }
        //    if (dm.Sorted != null && dm.Sorted.Count > 0) //Sorting
        //    {
        //        DataSource = operation.PerformSorting(DataSource, dm.Sorted);
        //    }
        //    if (dm.Where != null && dm.Where.Count > 0) //Filtering
        //    {
        //        DataSource = operation.PerformFiltering(DataSource, dm.Where, dm.Where[0].Operator);
        //    }
        //    int count = DataSource.Cast<ConsultationViewModel>().Count();
        //    if (dm.Skip != 0)
        //    {
        //        DataSource = operation.PerformSkip(DataSource, dm.Skip);         //Paging
        //    }
        //    if (dm.Take != 0)
        //    {
        //        DataSource = operation.PerformTake(DataSource, dm.Take);
        //    }
        //    return dm.RequiresCounts ? Json(new { result = DataSource, count = count }) : Json(DataSource);
        //}

        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Index(int id, ConsultationsViewModel consultationsViewModel)
        //{
        //    try
        //    {
        //        await _patientViewModelService.UpdatePatientWithFamily(consultationsViewModel.Patient);
        //        return RedirectToAction("Index", "Patient");
        //    }

        //    catch (Exception exp)
        //    {
        //        throw (exp);
        //    }
        //}
    }
}
