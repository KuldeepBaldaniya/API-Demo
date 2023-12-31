﻿using Azure;
using Microsoft.AspNetCore.Mvc;
using WEB_API_DEMO.Common;
using WEB_API_DEMO.Data;
using WEB_API_DEMO.Service.EmployeeService;

namespace WEB_API_DEMO.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class EmployeeController : Controller
    {
        // inisialize servises  
        private readonly IEmployeeService employeeService;
        public EmployeeController(IEmployeeService _employeeService)
        {
            employeeService = _employeeService;
        }

        [HttpGet("GetEmployee")]
        public async Task<ServiceResponse> GetEmployees()
        {
            var result = await employeeService.GetEmployees();
            if (result.Count > 0)
            {
                return new ServiceResponse
                {
                    Message = "List of Employee",
                    Response = result,
                    StatusCode = ServiceResponse.StatusCodeEnum.OK
                };
            }
            else
            {
                return new ServiceResponse
                {
                    Message = "There is no employee",
                    Response = result,
                    StatusCode = ServiceResponse.StatusCodeEnum.OK
                };
            }
        }

        [HttpGet("GetById/{id:guid}")]
        public async Task<ServiceResponse> GetEmployees([FromRoute] Guid id)
        {
            var result = await employeeService.GetEmployees(id);
            if (result != null)
            {
                return new ServiceResponse
                {
                    Message = "Employee Details",
                    Response = result,
                    StatusCode = ServiceResponse.StatusCodeEnum.OK
                };
            }
            else
            {
                return new ServiceResponse
                {
                    Message = "Employee not found",
                    Response = result,
                    StatusCode = ServiceResponse.StatusCodeEnum.NOT_FOUND
                };
            }
        }

        [HttpPost("CreateEmployee")]
        public async Task<ServiceResponse> AddEmployee(AddEmployeeRequest addemployeeRequest)
        {
            var result = await employeeService.AddEmployeerecors(addemployeeRequest);
            if (result)
            {
                return new ServiceResponse
                {
                    Message = "Employee Added",
                    Response = result,
                    StatusCode = ServiceResponse.StatusCodeEnum.CREATED
                };
            }
            else
            {
                return new ServiceResponse
                {
                    Message = "Somthing Wrong",
                    Response = result,
                    StatusCode = ServiceResponse.StatusCodeEnum.BAD_REQUEST
                };
            }
        }

        [HttpPut("Update/{id:guid}")]
        public async Task<ServiceResponse> UpdateEmployee([FromRoute] Guid id, AddEmployeeRequest employeeRequest)
        {
            var result = await employeeService.UpdateEmployee(id, employeeRequest);
            if (result)
            {
                return new ServiceResponse
                {
                    Message = "Employee Update",
                    Response = result,
                    StatusCode = ServiceResponse.StatusCodeEnum.OK
                };
            }
            else
            {
                return new ServiceResponse
                {
                    Message = "Somthing wrong",
                    Response = result,
                    StatusCode = ServiceResponse.StatusCodeEnum.BAD_REQUEST
                };
            }
        }

        [HttpDelete("Delete/{id:guid}")]
        public async Task<ServiceResponse> DeleteEmployee([FromRoute] Guid id, AddEmployeeRequest addEmployee)
        {
            var result = await employeeService.DeleteEmployee(id, addEmployee);
            if (result)
            {
                return new ServiceResponse
                {
                    Message = "Delete Success",
                    Response = result,
                    StatusCode = ServiceResponse.StatusCodeEnum.OK
                };
            }
            else
            {
                return new ServiceResponse
                {
                    Message = "Delete Not Success ",
                    Response = result,
                    StatusCode = ServiceResponse.StatusCodeEnum.BAD_REQUEST
                };
            }
        }
    }
}
