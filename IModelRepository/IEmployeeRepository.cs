using CommenReactProjectAPI.Model;
using System.Collections.Generic;

namespace CommenReactProjectAPI.IModelRepository
{
      public interface IEmployeeRepository
      {
            List<Employee> GetEmployeesList();

            List<Employee> GetEmployeeById(int id);

            int AddEmployee(Employee employee);

            int DeleteEmployee(int id);

            int UpdateEmployee(Employee employee);
      }
}
