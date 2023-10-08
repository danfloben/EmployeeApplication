using EmployeeApplication.Business.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeApplication.Business.Interface
{
    public interface IEmployeeServices
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployeeById(int Id);
    }
}
