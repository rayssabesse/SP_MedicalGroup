using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SPMedicalGroup.Domains;
using SPMedicalGroup.Interfaces;
using SPMedicalGroup.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SPMedicalGroup.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private IPatientRepository _patientRepository { get; set; }

        public PatientController()
        {
            _patientRepository = new PatientRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Patient> listPatient = _patientRepository.ListAll();
            return Ok(listPatient);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Patient patientSearched = _patientRepository.SearchId(id);
            if (patientSearched == null)
            {
                return NotFound("Nenhum paciente encontrado.");
            }
            return Ok(patientSearched);
        }
        
        
        [HttpPost]
        public IActionResult Post(Patient newPatient)
        {
            _patientRepository.Register(newPatient);
            return StatusCode(201);
        }

        
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _patientRepository.Delete(id);
            return StatusCode(204);
        }

        
        [HttpPut("{id}")]
        public IActionResult Put (int id, Patient refreshPatient)
        {
            Patient patientSearched = _patientRepository.SearchId(id);
            if (patientSearched == null)
            {
                return NotFound
                    (
                    new
                    {
                        message = "Paciente não encontrado.",
                        error = true
                    }
                    );
            }

            try
            {
                _patientRepository.Refresh(id, refreshPatient);
                return NoContent();
            }

            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpGet("appointments")]
        public IActionResult ListAppointments()
        {
            try
            {
                return Ok(_patientRepository.ListAppointments());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
