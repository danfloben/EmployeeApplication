using EmployeeApplication.Business.Entities;
using EmployeeApplication.Business.Interface;
using EmployeeApplication.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace EmployeeApplication.Controllers
{
    public class EmployeeApiController : ApiController
    {
        private readonly IEmployeeServices _employeeService;

        public EmployeeApiController(IEmployeeServices employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAllAsync()
        {
            try
            {
                List<Employee> employees = await _employeeService.GetEmployees();
                return GetResponse(employees);
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetByIdAsync(int id)
        {
            try
            {
                Employee employee = await _employeeService.GetEmployeeById(id);
                return GetResponse(employee);
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex.Message);
            }
        }

        private IHttpActionResult GetResponse(object data)
        {
            DataResponseModel response = new DataResponseModel
            {
                Status = data != null,
                Data = data,
                Message = data != null ? "Successfully! All records has been fetched." : "No records found."
            };
            return Ok(response);
        }

        private IHttpActionResult GetErrorResponse(string errorMessage)
        {
            ErrorResponseModel response = new ErrorResponseModel
            {
                Status = false,
                Message = errorMessage
            };
            return Json(response);
        }
    }
}
