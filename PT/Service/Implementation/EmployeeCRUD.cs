using DataLayer.API;
using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    internal class EmployeeCRUD : IEmployeeCRUD
    {
        private readonly IDataRepository _repository;

        public EmployeeCRUD(IDataRepository repository)
        {
            this._repository = repository;
        }

        private IEmployeeDTO Map(IEmployee employee)
        {
            return new EmployeeDTO(employee.EmployeeId, employee.Name, employee.Surname);
        }

        public async Task AddEmployee(int id, string firstName, string lastName)
        {
            await this._repository.AddEmployee(id, firstName, lastName);
        }

        public async Task DeleteEmployee(int id)
        {
            await this._repository.DeleteEmployee(id);
        }

        public async Task<Dictionary<int, IEmployeeDTO>> GetAllEmployees()
        {
            Dictionary<int, IEmployeeDTO> result = new Dictionary<int, IEmployeeDTO>();

            foreach (IEmployee employee in (await this._repository.GetAllEmployees()).Values)
            {
                result.Add(employee.EmployeeId, this.Map(employee));
            }

            return result;
        }

        public async Task<IEmployeeDTO> GetEmployee(int id)
        {
            return this.Map(await this._repository.GetEmployee(id));
        }

        public async Task<IEmployeeDTO> GetEmployeeAsyncMethodSyntax(int id)
        {
            return await Task.Run(() => this.Map(_repository.GetEmployee(id).Result));
        }

        public async Task<int> GetEmployeesCount()
        {
            return await this._repository.GetEmployeesCount();
        }

        public async Task UpdateEmployee(int id, string firstName, string lastName)
        {
            await this._repository.UpdateEmployee(id, firstName, lastName);
        }
    }
}
