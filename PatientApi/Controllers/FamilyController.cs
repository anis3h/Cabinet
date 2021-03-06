﻿using CommunCabinet.Dtos;
using CommunCabinet.MapperServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PatientApi.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class FamilyController : ControllerBase
    {
        private readonly IPatientMapperService _patientMapperService;

        public FamilyController(IPatientMapperService patientMapperService)
        {
            _patientMapperService = patientMapperService;
        }

        [Route("family/{id}")]
        [HttpGet]
        public async Task<ActionResult<FamilyPatientDto>> GetFamily(int id)
        {
            try
            {
                var patient = await _patientMapperService.GetPatientWithFamily(id);
                return patient;
            }
            catch (Exception exp)
            {
                throw (exp);
            }
        }

        [Route("family")]
        [HttpPost]
        public async Task<ActionResult<FamilyPatientDto>> UpdateFamily(FamilyPatientDto familyPatientDto)
        {
            if (ModelState.IsValid)
                return BadRequest(ModelState);

            int x = 0;
            int y = 5 / x;
            return await _patientMapperService.UpdatePatientWithFamily(familyPatientDto);
        }

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
