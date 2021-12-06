using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SPMedicalGroup.Domains;
using SPMedicalGroup.Interfaces;
using SPMedicalGroup.Repositories;
using SPMedicalGroup.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SPMedicalGroup.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUserrRepository _userRepository { get; set; }
        public LoginController ()
        {
            _userRepository = new UserRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                Userr userSearched = _userRepository.Login(login.Email, login.Password);
                if (userSearched == null)
                {
                    return BadRequest("E-mail ou senha inválidos.");
                }

                var myClaims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, userSearched.EmailUser),
                    new Claim(JwtRegisteredClaimNames.Jti, userSearched.IdUser.ToString()),
                    new Claim(ClaimTypes.Role, userSearched.IdUserType.ToString())
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("spmedical-authentication-key"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var myToken = new JwtSecurityToken(
                    issuer: "SPMedicalGroup.webAPI",
                    audience: "SPMedicalGroup.webAPI",
                    claims: myClaims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(myToken)
                });
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
