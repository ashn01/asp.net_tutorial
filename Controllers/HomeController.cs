using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyApp.Models;
using MyApp.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Student()
        {
            List<Teacher> teachers = new List<Teacher>()
            {
                new Teacher() {Name = "Alex", Class="English"},
                new Teacher() { Name= "Don", Class="Math"},
                new Teacher() {Name = "Peter", Class="Science"},
                new Teacher() { Name= "Paul", Class="History"}
            };

            var viewModel = new StudentTeacherViewModel()
            {
                Student = new Student(),
                Teachers = teachers
            };

            return View(viewModel);
        }

        [HttpPost] // post request
        [ValidateAntiForgeryToken] // validate token
        public IActionResult Student(StudentTeacherViewModel model) // student model
        {
            // validate
            if(ModelState.IsValid) 
            {
                // store data
            }
            else
            {
                // error
            }

            return View();
        }

        public IActionResult Index()
        {
            List<Teacher> teachers = new List<Teacher>()
            {
                new Teacher() {Name = "Alex", Class="English"},
                new Teacher() { Name= "Don", Class="Math"},
                new Teacher() {Name = "Peter", Class="Science"},
                new Teacher() { Name= "Paul", Class="History"}
            };

            var viewModel = new StudentTeacherViewModel()
            {
                Student = new Student(),
                Teachers = teachers
            };

            return View(viewModel);
        }
    }
}
