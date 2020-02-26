﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Required Field")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Required Field")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Required Field")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Required Field")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password not match")]
        public string ConfirmPassword { get; set; }


    }
}
