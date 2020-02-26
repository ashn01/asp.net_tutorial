using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly MyAppContext _context;
        public StudentRepository(MyAppContext context)
        {
            _context = context;
        }

        public void AddStudent(Student student)
        {
            _context.Students.Add(student); // ready to add entity
        }

        public void Save()
        {
            _context.SaveChanges(); // save changes to db
        }

        public IEnumerable<Student> GetAllStudents()
        {
            var result = _context.Students.ToList();
            return result;
        }

        public Student GetStudent(int id)
        {
            var result = _context.Students.Find(id);

            return result;
        }

        public void Edit(Student student)
        {
            _context.Students.Update(student);
        }

        public void Delete(Student student)
        {
            _context.Students.Remove(student);
        }
    }
}
