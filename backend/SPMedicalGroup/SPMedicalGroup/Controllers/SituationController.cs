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
    public class SituationController : ControllerBase
    {
        private ISituationRepository _situationRepository { get; set; }
        public SituationController()
        {
            _situationRepository = new SituationRepository();
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<Situation> listSituation = _situationRepository.ListAll();
            return Ok(listSituation);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Situation SituationSearched = _situationRepository.SearchId(id);
            if (SituationSearched == null)
            {
                return NotFound("Nenhuma situação encontrada.");
            }

            return Ok(SituationSearched);
        }

        
        [HttpPost]
        public IActionResult Post(Situation newSituation)
        {
            _situationRepository.Register(newSituation);

            return StatusCode(201);
        }

       
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _situationRepository.Delete(id);
            return StatusCode(204);
        }

      
        [HttpPut("{id}")]
        public IActionResult Put(int id, Situation rerfreshSituation)
        {
            Situation searchedSituation = _situationRepository.SearchId(id);

            if (searchedSituation == null)
            {
                return NotFound(
                    new
                    {
                        message = "Situação não encontrada.",
                        error = true
                    }
                    );
            }
            try
            {
                _situationRepository.Refresh(id, rerfreshSituation);
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
                return Ok(_situationRepository.ListAppointments());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
