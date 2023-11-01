using Microsoft.AspNetCore.Mvc;
using WEB_API_DEMO.Data;

namespace WEB_API_DEMO.Service.EmployeeService
{
    public interface IEmployeeService
    {
        Task<List<AddEmployeeRequest>> GetEmployees();
        Task<AddEmployeeRequest> GetEmployees(Guid id);
        Task<bool> AddEmployeerecors(AddEmployeeRequest request);
        Task<bool> UpdateEmployee(Guid id, AddEmployeeRequest employeeRequest);
        Task<bool> DeleteEmployee(Guid id, AddEmployeeRequest addEmployee); 
    }
}
