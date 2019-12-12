using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore22Intro.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }


        [Required, DataType(DataType.Password)]
        public string Password { get; set; }


        public string ReturnUrl { get; set; }


        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
