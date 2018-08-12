using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cabinet.Interfaces;
using Cabinet.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Cabinet.Controllers
{

    public class PatientController : Controller
    {
        IPatientViewModelService _patientViewModelService;

        public PatientController(IPatientViewModelService patientViewModelService)
        {
            _patientViewModelService = patientViewModelService;
        }

        // GET: /<controller>/

        [HttpGet]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Index(int? patientFilterApplied, int? typesFilterApplied, int? page)
        {
            var patientModel = await _patientViewModelService.GetPatientItems();
            return View(patientModel);
        }

        [HttpGet("Error")]
        public IActionResult Error()
        {
            return View();
        }

        // [Route("patient/editPatient")]
        [HttpGet("[controller]/[action]/{id}")]
        public async Task<IActionResult> EditPatient([FromRoute] int id)
        {
            var patientModel = await _patientViewModelService.GetPatient(id);
            //  ViewData["Title"] = "Modification du challenge " + p.ProjectName;
            return View(patientModel);
        }

        [HttpPost("[controller]/[action]")]
        public IActionResult EditPatient()
        {
            return View();
        }
    }
}
