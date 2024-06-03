using DataLayer.API;
using Service.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.API
{
    public interface IEmployeeCRUD
    {
        static IEmployeeCRUD CreateEmployeeCRUD(IDataRepository? dataRepository = null)
        {
            return new EmployeeCRUD(dataRepository ?? IDataRepository.CreateDatabase(ConnectionString.GetConnectionString()));
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
