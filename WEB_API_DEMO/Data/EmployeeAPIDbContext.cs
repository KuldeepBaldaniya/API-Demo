
using Microsoft.EntityFrameworkCore;
using API_DEMO.Models;

namespace API_DEMO.Data
{
    public class EmployeeAPIDbContext : DbContext
    {
        public EmployeeAPIDbContext(DbContextOptions options) : base(options) 
        {
            
        }
       public DbSet<Employee> Employees { get; set; }
    }
}
