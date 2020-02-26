using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public DbSeeder(MyAppContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
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

            var adminAccount = await _userManager.FindByNameAsync("admin@test.com"); // assign admin role
            var adminRole = new IdentityRole("Admin");
            await _roleManager.CreateAsync(adminRole);
            await _userManager.AddToRoleAsync(adminAccount, adminRole.Name);
        }
    }
}
