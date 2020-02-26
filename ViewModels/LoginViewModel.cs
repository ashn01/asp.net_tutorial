using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Required Field")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Required Field")]
        [DataType(DataType.Password)]
        public string Password { set; get; }
    }
}
