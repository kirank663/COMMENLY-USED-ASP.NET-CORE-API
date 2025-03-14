using CommenReactProjectAPI.Model;
using System.Collections.Generic;

namespace CommenReactProjectAPI.IModelRepository
{
      public interface IDepartmentRepository
      {
            List<Department> GetDepartmentList();

            List<Department> GetDepartmentById(int id);

            int AddDepartment(Department department);

            int DeleteDepartment(int id);

            int UpdateDepartment(Department department);

           // bool CheckDeptUsedAnywhere(int departmentId);
      }
}
