﻿using CommunCabinet.Dtos;
using CommunCabinet.MapperServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace InformationsApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class InformationsController : ControllerBase
    {
        private readonly IPatientMapperService _patientMapperService;

        public InformationsController(IPatientMapperService patientMapperService)
        {
            _patientMapperService = patientMapperService;
        }

        // GET: api/Informations/information/5
        [Route("Information/{id}")]
        [HttpGet]
        public async Task<IActionResult> Information(int id)
        {
            var patient = await _patientMapperService.GetPatientWithInformation(id);
            return new JsonResult(patient);
        }

        //POST: api/Informations
        [Route("Informations")]
        [HttpPost]
        public async Task<IActionResult> Informations(PatientInformationDto patientInformationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _patientMapperService.UpdatePatientWithInformation(patientInformationDto);
                return Ok();
            }
            catch (Exception exp)
            {
                throw (exp);
            }
        }

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
