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
    public class UserTypeController : ControllerBase
    {
        private IUserTypeRepository _userTypeRepository { get; set; }

        public UserTypeController()
        {
            _userTypeRepository = new UserTypeRepository();
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<UserType> listUserType = _userTypeRepository.ListAll();
            return Ok(listUserType);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            UserType UserTypeSearched = _userTypeRepository.SearchId(id);
            if (UserTypeSearched == null)
            {
                return NotFound("Nenhuma especialidade encontrada.");
            }

            return Ok(UserTypeSearched);
        }

    
        [HttpPost]
        public IActionResult Post(UserType newUserType)
        {
            _userTypeRepository.Register(newUserType);

            return StatusCode(201);
        }


        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _userTypeRepository.Delete(id);
            return StatusCode(204);
        }

     
        [HttpPut("{id}")]
        public IActionResult Put(int id, UserType rerfreshUserType)
        {
            UserType searchedUserType = _userTypeRepository.SearchId(id);

            if (searchedUserType == null)
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
                _userTypeRepository.Refresh(id, rerfreshUserType);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpGet("users")]
        public IActionResult ListUsers()
        {
            try
            {
                return Ok(_userTypeRepository.ListUsers());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
