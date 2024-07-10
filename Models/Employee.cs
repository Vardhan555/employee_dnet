using System;
using employee.Data;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;

namespace employee.Models
{

    public class EmployeeContext : ApplicationDbContext
    {
        public EmployeeContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }

    public class Employee
	{
		public int id { get; set; }
		public string? name { get; set; }
        [Required]
        public string? email { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public string? Gender { get; set; }
    }
}

