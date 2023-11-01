
using Microsoft.EntityFrameworkCore;
using WEB_API_DEMO.Models;

namespace WEB_API_DEMO.Data
{
    public class EmployeeAPIDbContext : DbContext
    {
        public EmployeeAPIDbContext(DbContextOptions options) : base(options) 
        {
            
        }
       public DbSet<Employee> Employees { get; set; }
    }
}
