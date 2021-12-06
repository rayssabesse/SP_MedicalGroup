using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace SPMedicalGroup.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o e-mail de usuário.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe a senha de usuário.")]
        public string Password { get; set; }
    }
}
