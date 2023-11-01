using Microsoft.AspNetCore.Mvc;
using WEB_API_DEMO.Data;
using WEB_API_DEMO.Models;

namespace WEB_API_DEMO.Ripository.Ripository
{
    public interface IEmployeeRepository
    {
        Task<List<AddEmployeeRequest>> GetEmployees();
        Task<AddEmployeeRequest> GetEmployees(Guid id);
        Task<bool> AddEmployee(AddEmployeeRequest addemployeeRequest);
        Task<bool> UpdateEmployee(Guid id, AddEmployeeRequest employeeRequest);
        Task<bool> DeleteEmployees(Guid id);
    }
}
