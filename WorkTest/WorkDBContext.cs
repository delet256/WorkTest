using Microsoft.EntityFrameworkCore;
using WorkTest.Models;

namespace WorkTest
{
    public class WorkDBContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        public WorkDBContext(DbContextOptions<WorkDBContext> options) : base(options) { }
    }
}
