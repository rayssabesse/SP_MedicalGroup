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
    public class ClinicController : ControllerBase
    {
        private IClinicRepository _clinicRepository { get; set; } 
        public ClinicController()
        {
            _clinicRepository = new ClinicRepository(); 
        }

        [HttpPost]
        public IActionResult Post(Clinic newCLinic)
        {
            _clinicRepository.Register(newCLinic);

            return StatusCode(201);
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Clinic> listClinic = _clinicRepository.ListAll();
            return Ok(listClinic);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Clinic clinicSearched = _clinicRepository.SearchId(id);
            if (clinicSearched == null)
            {
                return NotFound("Nenhua clínica encontrada.");
            }
            return Ok(clinicSearched);
        }

       
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _clinicRepository.Delete(id);
            return StatusCode(204);
        }

       
        [HttpPut("{id}")]
        public IActionResult Put(int id, Clinic refreshClinic)
        {
            Clinic clinicSearched = _clinicRepository.SearchId(id);
            if (clinicSearched == null)
            {
                return NotFound
                    (
                    new
                    {
                        message = "Clínica não encontrada.",
                        error = true
                    });
            }
            try
            {
                _clinicRepository.Refresh(id, refreshClinic);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpGet("doctors")]
        public IActionResult ListDoctors()
        {
            try
            {
                return Ok(_clinicRepository.ListDoctors());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
