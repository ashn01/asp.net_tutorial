using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Data
{
    public class DbSeeder
    {
        private MyAppContext _context;
        public DbSeeder(MyAppContext context)
        {
            _context = context;
        }

        public async Task SeedDatabase()
        {
            if (!_context.Teachers.Any())
            {
                List<Teacher> teachers = new List<Teacher>()
                {
                    new Teacher() {Name = "Alex", Class="English"},
                    new Teacher() { Name= "Don", Class="Math"},
                    new Teacher() {Name = "Peter", Class="Science"},
                    new Teacher() { Name= "Paul", Class="History"}
                };

                await _context.AddRangeAsync(teachers); // add list data to table
                //await _context.AddAsync(new Teacher() { Name = "Alex", Class = "English" }); // add a data to table
                await _context.SaveChangesAsync();
            }
        }
    }
}
