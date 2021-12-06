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
    public class AppointmentController : ControllerBase
    {
        private IAppointmentRepository _appointmentRepository { get; set; }

        public AppointmentController()
        {
            _appointmentRepository = new AppointmentRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Appointment> listAppointments = _appointmentRepository.ListAll();
            return Ok(listAppointments);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Appointment appointmentSearched = _appointmentRepository.SearchId(id);
            if (appointmentSearched == null)
            {
                return NotFound("Nenhuma consulta encontrada.");
            }

            return Ok(appointmentSearched);
        }   

        
        [HttpPost]
        public IActionResult Post(Appointment newAppointment)
        {
            _appointmentRepository.Register(newAppointment);
            return StatusCode(201);
        }

       
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _appointmentRepository.Delete(id);
            return StatusCode(204);
        }

       
        [HttpPut("{id}")]
        public IActionResult Put (int id, Appointment refreshAppointment)
        {
            Appointment appointmentSearched = _appointmentRepository.SearchId(id);
            if (appointmentSearched == null)
            {
                return NotFound
                    (
                    new{
                        message = "Consulta não encontrada.",
                        error = true
                    });
            }
            try
            {
                _appointmentRepository.Refresh(id, refreshAppointment);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

    }
}
