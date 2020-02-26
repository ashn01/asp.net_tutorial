using MyApp.Models;
using System.Collections.Generic;

namespace MyApp.Data.Repositories
{
    public interface IStudentRepository
    {
        void AddStudent(Student student);
        IEnumerable<Student> GetAllStudents();
        Student GetStudent(int id);
        void Save();
        public void Edit(Student student);
        public void Delete(Student student);
    }
}