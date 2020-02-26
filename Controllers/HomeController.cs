using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApp.Data.Repositories;
using MyApp.Models;
using MyApp.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IStudentRepository _studentRepository;
        public HomeController(ITeacherRepository teacherRepository, IStudentRepository studentRepository)
        {
            _teacherRepository = teacherRepository;
            _studentRepository = studentRepository;
        }

        // GET: /<controller>/
        [Authorize(Roles ="Admin")] // login needed
        
        public IActionResult Student()
        {
            var students = _studentRepository.GetAllStudents();

            var viewModel = new StudentTeacherViewModel()
            {
                Student = new Student(),
                Students = students
            };

            return View(viewModel);
        }

        [HttpPost] // post request
        [ValidateAntiForgeryToken] // validate token
        [Authorize(Roles = "Admin")]
        public IActionResult Student(StudentTeacherViewModel model) // student model
        {
            // validate
            if (ModelState.IsValid)
            {
                // store data
                _studentRepository.AddStudent(model.Student);
                _studentRepository.Save();
                ModelState.Clear(); // delete input values
            }
            else
            {
                // error
            }
            var students = _studentRepository.GetAllStudents();
            var viewModel = new StudentTeacherViewModel()
            {
                Student = new Student(),
                Students = students
            };

            
            return View(viewModel);
        }

        [Authorize]
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

        public IActionResult Detail(int id)
        {
            var result = _studentRepository.GetStudent(id);
            return View(result); // not a good design, should result as viewmodel not entity
        }

        public IActionResult Edit(int id)
        {
            var result = _studentRepository.GetStudent(id);

            return View(result); // not a good design, should result as viewmodel not entity
        }

        [HttpPost] // post request
        [ValidateAntiForgeryToken] // validate token
        public IActionResult Edit(Student student) // student model
        {
            // validate
            if (ModelState.IsValid)
            {
                _studentRepository.Edit(student);
                _studentRepository.Save();

                return RedirectToAction("Student"); // redirect
            }


            return View(student);
        }

        public IActionResult Delete(int id)
        {
            var result = _studentRepository.GetStudent(id);

            if(result != null)
            {
                _studentRepository.Delete(result);
                _studentRepository.Save();
            }

            return RedirectToAction("Student");
        }
    }
}
