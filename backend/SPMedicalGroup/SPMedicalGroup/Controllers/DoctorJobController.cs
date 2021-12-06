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
    public class DoctorJobController : ControllerBase
    {
        private IDoctorJobRepository _doctorJobRepository { get; set; }
        public DoctorJobController ()
        {
            _doctorJobRepository = new DoctorJobRepository ();
        }
        [HttpGet]  
        public IActionResult Get()
        {
            List<DoctorJob> listDoctorJob = _doctorJobRepository.ListAll();
            return Ok(listDoctorJob);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            DoctorJob doctorJobSearched = _doctorJobRepository.SearchId(id);
            if (doctorJobSearched == null)
            {
                return NotFound("Nenhuma especialidade encontrada.");
            }

            return Ok(doctorJobSearched);
        }

  
        [HttpPost]
        public IActionResult Post(DoctorJob newDoctorJob)
        {
            _doctorJobRepository.Register(newDoctorJob);

            return StatusCode(201);
        }

  
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _doctorJobRepository.Delete(id);
            return StatusCode(204);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, DoctorJob refreshDoctorJob)
        {
            DoctorJob searchedSpecialty = _doctorJobRepository.SearchId(id);

            if (searchedSpecialty == null)
            {
                return NotFound(
                    new
                    {
                        message = "Especialidade não encontrada.",
                        error = true
                    }
                    );
            }
            try
            {
                _doctorJobRepository.Refresh(id, refreshDoctorJob);
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
                return Ok(_doctorJobRepository.ListDoctors());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


    }
}
