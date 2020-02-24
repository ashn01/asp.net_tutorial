using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        // [BindNever] will not receive data
        [Required]
        [MaxLength(50)] // data annotation
        public string Name { get; set; }
        [Required]
        [Range(15,70)]
        public int Age { get; set; }
        [Required, MinLength(5)]
        public string Country { get; set; }
    }
}
