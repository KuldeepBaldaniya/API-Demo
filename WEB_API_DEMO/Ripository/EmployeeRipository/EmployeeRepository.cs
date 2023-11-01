using Microsoft.EntityFrameworkCore;
using WEB_API_DEMO.Data;
using WEB_API_DEMO.Models;

namespace WEB_API_DEMO.Ripository.Ripository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeAPIDbContext employeeAPIDbContext;
        public EmployeeRepository(EmployeeAPIDbContext _employeeAPIDbContext)
        {
            employeeAPIDbContext = _employeeAPIDbContext;
        }


        public async Task<List<AddEmployeeRequest>> GetEmployees()
        {
            try
            {
                var employee = await employeeAPIDbContext.Employees.Select(x => new AddEmployeeRequest
                {
                    id = x.id,
                    name = x.name,
                    email = x.email,
                    phone = x.phone,
                    address = x.address
                }).ToListAsync();
                return employee;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<AddEmployeeRequest> GetEmployees(Guid ID)
        {
            try
            {
                var employee = await employeeAPIDbContext.Employees.Where(x => x.id == ID).Select(x => new AddEmployeeRequest()
                {
                    id = x.id,
                    name = x.name,
                    email = x.email,
                    phone = x.phone,
                    address = x.address
                }).FirstOrDefaultAsync();

                if (employee == null)
                {

                    return null;
                }
                return employee;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> AddEmployee(AddEmployeeRequest addemployeeRequest)
        {
            try
            {
                var employee = new Employee()
                {
                    id = Guid.NewGuid(),
                    name = addemployeeRequest.name,
                    email = addemployeeRequest.email,
                    phone = addemployeeRequest.phone,
                    address = addemployeeRequest.address,
                };
                await employeeAPIDbContext.Employees.AddAsync(employee);
                await employeeAPIDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {             
                return false;
            }
        }

        public async Task<bool> UpdateEmployee(Guid id, AddEmployeeRequest employeeRequest)
        {
            try
            {
                var employee = await employeeAPIDbContext.Employees.FindAsync(id);
                if (employee != null)
                {
                    employee.name = employeeRequest.name;
                    employee.email = employeeRequest.email;
                    employee.phone = employeeRequest.phone;
                    employee.address = employeeRequest.address;

                    employeeAPIDbContext.Employees.Update(employee);
                    await employeeAPIDbContext.SaveChangesAsync();

                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        public async Task<bool> DeleteEmployees(Guid id)
        {
            try
            {
                var delete = await employeeAPIDbContext.Employees.Where(x => x.id == id).FirstOrDefaultAsync();
                if (delete != null)
                {
                    employeeAPIDbContext.Employees.Remove(delete);
                    await employeeAPIDbContext.SaveChangesAsync();

                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }
    }
}
