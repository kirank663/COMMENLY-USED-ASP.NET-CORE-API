using CommenReactProjectAPI.CommenFunction;
using CommenReactProjectAPI.DatabaseOperation;
using CommenReactProjectAPI.IModelRepository;
using CommenReactProjectAPI.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace CommenReactProjectAPI.ModelRepository
{
      public class DepartmentRepository : IDepartmentRepository
      {
            DatabaseOperations _dbOperation = DatabaseOperations.GetInstance;
            public int AddDepartment(Department department)
            {
                  try
                  {
                        SqlParameter[] _sqlParam = new SqlParameter[3];
                        _sqlParam[0] = new SqlParameter("@Choice" , "I");
                        _sqlParam[1] = new SqlParameter("@DeptName" , department.DeptName);
                        _sqlParam[2] = new SqlParameter("@Username" , "kirankos");
                        return _dbOperation.ExecuteInsertUpdateDelete(_sqlParam , ProcedureList.Proc_DepartmentAPI);
                  }
                  catch(Exception ex)
                  {
                  }
                  return 0;
            }

            public int DeleteDepartment(int id)
            {
                  try
                  {
                        SqlParameter[] _sqlParam = new SqlParameter[2];
                        _sqlParam[0] = new SqlParameter("@Choice" , "D");
                        _sqlParam[1] = new SqlParameter("@DeptId" , id);
                        return _dbOperation.ExecuteInsertUpdateDelete(_sqlParam , ProcedureList.Proc_DepartmentAPI);
                  }
                  catch(Exception ex)
                  {
                  }
                  return 0;
            }

            public List<Department> GetDepartmentById(int id)
            {
                  SqlParameter[] _sqlParam = new SqlParameter[2];
                  _sqlParam[0] = new SqlParameter("@Choice" , "B");
                  _sqlParam[1] = new SqlParameter("@DeptId" , id);
                  var _deptDetails = CommenFunctions.ConvertDataTableToList<Department>(_dbOperation.ExecuteDataTable(_sqlParam , ProcedureList.Proc_DepartmentAPI));
                  return _deptDetails;
            }

            public List<Department> GetDepartmentList()
            {
                  SqlParameter[] _sqlParam = new SqlParameter[1];
                  _sqlParam[0] = new SqlParameter("@Choice" , "S");
                  var _deptList = CommenFunctions.ConvertDataTableToList<Department>(_dbOperation.ExecuteDataTable(_sqlParam , ProcedureList.Proc_DepartmentAPI));
                  return _deptList;
            }

            public int UpdateDepartment(Department department)
            {
                  try
                  {
                        SqlParameter[] _sqlParam = new SqlParameter[4];
                        _sqlParam[0] = new SqlParameter("@Choice" , "U");
                        _sqlParam[1] = new SqlParameter("@DeptId" , department.DeptId);
                        _sqlParam[2] = new SqlParameter("@DeptName" , department.DeptName);
                        _sqlParam[3] = new SqlParameter("@Username" , "kirankos");
                        return _dbOperation.ExecuteInsertUpdateDelete(_sqlParam , ProcedureList.Proc_DepartmentAPI);
                  }
                  catch(Exception ex)
                  {
                  }
                  return 0;
            }
      }
}
