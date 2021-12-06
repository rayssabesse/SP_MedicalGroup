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
    public class UsersController : ControllerBase
    {
        private IUserrRepository _userRepository { get; set; }
        
        public UsersController()
        {
            _userRepository = new UserRepository();
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<Userr> listUser_ = _userRepository.ListAll();
            return Ok(listUser_);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Userr User_Searched = _userRepository.SearchId(id);
            if (User_Searched == null)
            {
                return NotFound("Nenhuma especialidade encontrada.");
            }

            return Ok(User_Searched);
        }

       
        [HttpPost]
        public IActionResult Post(Userr newUser)
        {
            _userRepository.Register(newUser);

            return StatusCode(201);
        }


        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _userRepository.Delete(id);
            return StatusCode(204);
        }

       
        [HttpPut("{id}")]
        public IActionResult Put(int id, Userr refreshUser)
        {
            Userr searchedUser_ = _userRepository.SearchId(id);

            if (searchedUser_ == null)
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
                _userRepository.Refresh(id, refreshUser);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpGet("patients")]
        public IActionResult ListPatients()
        {
            try
            {
                return Ok(_userRepository.ListPatients());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("doctors")]
        public IActionResult ListDoctors()
        {
            try
            {
                return Ok(_userRepository.ListDoctors());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
