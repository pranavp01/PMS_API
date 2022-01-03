﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMS_Business.Interfaces;
using PMS_Models;
using Microsoft.AspNetCore.Authorization;
using PMS_API.Model;

namespace PMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PatientController : ControllerBase
    {
        private readonly IPatientBusiness _patientBusiness;
        public PatientController(IPatientBusiness patientBusiness)
        {
            _patientBusiness = patientBusiness;
        }

        [HttpGet]
        [Authorize(Roles = "Patient,Admin,Physician,Nurse")]
        public async Task<ActionResult<IEnumerable<PatientModel>>> GetAllPatients()
        {
            var patients = await _patientBusiness.GetAll();
            return Ok(patients);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<bool>> AddPatient([FromBody]PatientModel patientModel)
        {
            try
            {
                var result = await _patientBusiness.AddPatient(patientModel);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
