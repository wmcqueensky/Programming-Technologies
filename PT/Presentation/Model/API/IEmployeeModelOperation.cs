using DataLayer.API;
using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model.API
{
    public interface IEmployeeModelOperation
    {
        static IEmployeeModelOperation CreateModelOperation(IEmployeeCRUD? employeeCrud = null)
        {
            return new EmployeeModelOperation(employeeCrud ?? IEmployeeCRUD.CreateEmployeeCRUD());
        }

        Task AddEmployee(int id, string firstName, string lastName);
        Task<IEmployeeDTO> GetEmployee(int id);
        Task<IEmployeeDTO> GetEmployeeAsyncMethodSyntax(int id);
        Task UpdateEmployee(int id, string firstName, string lastName);
        Task DeleteEmployee(int id);
        Task<Dictionary<int, IEmployeeDTO>> GetAllEmployees();
        Task<int> GetEmployeesCount();
    }
}
