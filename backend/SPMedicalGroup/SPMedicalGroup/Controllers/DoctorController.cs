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
    public class DoctorController : ControllerBase
    {
        private IDoctorRepository _doctorRepository { get; set; }
        public DoctorController()
        {
            _doctorRepository = new DoctorRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Doctor> listDoctor = _doctorRepository.ListAll();
            return Ok(listDoctor);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Doctor DoctorSearched = _doctorRepository.SearchId(id);
            if (DoctorSearched == null)
            {
                return NotFound("Nenhum médico encontrado.");
            }
            return Ok(DoctorSearched);
        }

       
        [HttpPost]
        public IActionResult Post(Doctor newDoctor)
        {
            _doctorRepository.Register(newDoctor);
            return StatusCode(201);
        }
        
       
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _doctorRepository.Delete(id);
            return StatusCode(204);
        }

        
        [HttpPut("{id}")]
        public IActionResult Put(int id, Doctor refreshDoctor)
        {
            Doctor DoctorSearched = _doctorRepository.SearchId(id);
            if (DoctorSearched == null)
            {
                return NotFound
                    (
                    new
                    {
                        message = "Médico não encontrado.",
                        error = true
                    }
                    );
            }
                
            try
            {
                _doctorRepository.Refresh(id, refreshDoctor);
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
                return Ok(_doctorRepository.ListAppointments());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
