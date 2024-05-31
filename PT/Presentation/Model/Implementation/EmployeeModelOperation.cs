using DataLayer.API;
using Presentation.Model.API;
using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model.Implementation
{
    internal class EmployeeModelOperation : IEmployeeModelOperation
    {
        private IEmployeeCRUD _employeeCrud;

        public EmployeeModelOperation(IEmployeeCRUD? employeeCrud = null)
        {
            this._employeeCrud = employeeCrud ?? IEmployeeCRUD.CreateEmployeeCRUD();
        }

        private IEmployeeModel Map(IEmployeeDTO employee)
        {
            return new EmployeeModel(employee.EmployeeId, employee.Name, employee.Surname);
        }
        public async Task AddEmployee(int id, string firstName, string lastName)
        {
            await this._employeeCrud.AddEmployee(id, firstName, lastName);
        }

        public async Task DeleteEmployee(int id)
        {
            await this._employeeCrud.DeleteEmployee(id);
        }

        public async Task<Dictionary<int, IEmployeeModel>> GetAllEmployees()
        {
            Dictionary<int, IEmployeeModel> result = new Dictionary<int, IEmployeeModel>();

            foreach (IEmployeeDTO employee in (await this._employeeCrud.GetAllEmployees()).Values)
            {
                result.Add(employee.EmployeeId, this.Map(employee));
            }

            return result;
        }

        public async Task<IEmployeeModel> GetEmployee(int id)
        {
            return this.Map(await this._employeeCrud.GetEmployee(id));
        }

        public async Task<IEmployeeModel> GetEmployeeAsyncMethodSyntax(int id)
        {
            return await Task.Run(() => this.Map(_employeeCrud.GetEmployee(id).Result));
        }

        public async Task<int> GetEmployeesCount()
        {
            return await this._employeeCrud.GetEmployeesCount();
        }

        public async Task UpdateEmployee(int id, string firstName, string lastName)
        {
            await this._employeeCrud.UpdateEmployee(id, firstName, lastName);
        }
    }
}
