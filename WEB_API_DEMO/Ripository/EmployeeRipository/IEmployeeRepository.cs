using Microsoft.AspNetCore.Mvc;
using API_DEMO.Data;
using API_DEMO.Models;

namespace API_DEMO.Ripository.Ripository
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
