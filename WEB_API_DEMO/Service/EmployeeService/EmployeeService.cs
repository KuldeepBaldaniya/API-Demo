using WEB_API_DEMO.Data;
using WEB_API_DEMO.Ripository.Ripository;

namespace WEB_API_DEMO.Service.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        public EmployeeService(IEmployeeRepository _employeeRepository)
        {
            employeeRepository = _employeeRepository;
        }

        public async Task<List<AddEmployeeRequest>> GetEmployees()
        {
            var result = await employeeRepository.GetEmployees();
            return result;
        }

        public async Task<AddEmployeeRequest> GetEmployees(Guid Id)
        {
            var result = await employeeRepository.GetEmployees(Id);
            return result;
        }

        public async Task<bool> AddEmployeerecors(AddEmployeeRequest request)
        {
            var result = await employeeRepository.AddEmployee(request);
            return result;
        }

        public async Task<bool> UpdateEmployee(Guid id, AddEmployeeRequest employeeRequest)
        {
            var result = await employeeRepository.UpdateEmployee(id, employeeRequest);
            return result;
        }

        public async Task<bool> DeleteEmployee(Guid id)
        {
            var delete = await employeeRepository.DeleteEmployees(id);
            return delete;
        }
    }
}
