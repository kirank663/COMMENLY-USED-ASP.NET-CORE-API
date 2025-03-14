using CommenReactProjectAPI.CommenFunction;
using CommenReactProjectAPI.DatabaseOperation;
using CommenReactProjectAPI.IModelRepository;
using CommenReactProjectAPI.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace CommenReactProjectAPI.ModelRepository
{
      public class EmployeeRepository : IEmployeeRepository
      {
            DatabaseOperations _dbOperation = DatabaseOperations.GetInstance;
            public int AddEmployee(Employee employee)
            {
                  try
                  {
                        SqlParameter[] _sqlParam = new SqlParameter[14];
                        _sqlParam[0] = new SqlParameter("@Choice" , "I");
                        _sqlParam[1] = new SqlParameter("@FName" , employee.FName);
                        _sqlParam[2] = new SqlParameter("@LName" , employee.LName);
                        _sqlParam[3] = new SqlParameter("@Email" , employee.Email);
                        _sqlParam[4] = new SqlParameter("@PhoneNo" , employee.PhoneNo);
                        _sqlParam[5] = new SqlParameter("@DateOfBirth" , employee.DateOfBirth);
                        _sqlParam[6] = new SqlParameter("@Position" , employee.Position);
                        _sqlParam[7] = new SqlParameter("@Department" , employee.Department);
                        _sqlParam[8] = new SqlParameter("@Address" , employee.Address);
                        _sqlParam[9] = new SqlParameter("@City" , employee.City);
                        _sqlParam[10] = new SqlParameter("@State" , employee.State);
                        _sqlParam[11] = new SqlParameter("@Zipcode" , employee.Zipcode);
                        _sqlParam[12] = new SqlParameter("@JoiningDate" , employee.JoiningDate);
                        _sqlParam[13] = new SqlParameter("@Username" , "kirankos");
                        return _dbOperation.ExecuteInsertUpdateDelete(_sqlParam , ProcedureList.Proc_EmployeeMgmtAPI);
                  }
                  catch(Exception ex)
                  {
                  }
                  return 0;
            }

            public int DeleteEmployee(int id)
            {
                  try
                  {
                        SqlParameter[] _sqlParam = new SqlParameter[2];
                        _sqlParam[0] = new SqlParameter("@Choice" , "D");
                        _sqlParam[1] = new SqlParameter("@Id" , id);
                        return _dbOperation.ExecuteInsertUpdateDelete(_sqlParam , ProcedureList.Proc_EmployeeMgmtAPI);
                  }
                  catch(Exception ex)
                  {
                  }
                  return 0;
            }

            public List<Employee> GetEmployeeById(int id)
            {
                  List<Employee> employeeList = new List<Employee>();
                  try
                  {
                        SqlParameter[] _sqlParam = new SqlParameter[2];
                        _sqlParam[0] = new SqlParameter("@Choice" , "B");
                        _sqlParam[1] = new SqlParameter("@Id" , id);
                        employeeList = CommenFunctions.ConvertDataTableToList<Employee>(_dbOperation.ExecuteDataTable(_sqlParam , ProcedureList.Proc_EmployeeMgmtAPI));
                  }
                  catch(Exception ex) { return employeeList; }
                  return employeeList;
            }

            public List<Employee> GetEmployeesList()
            {
                  List<Employee> employeeList = new List<Employee>();
                  try
                  {
                        SqlParameter[] _sqlParam = new SqlParameter[1];
                        _sqlParam[0] = new SqlParameter("@Choice" , "S");
                        employeeList = CommenFunctions.ConvertDataTableToList<Employee>(_dbOperation.ExecuteDataTable(_sqlParam , ProcedureList.Proc_EmployeeMgmtAPI));
                  }
                  catch(Exception ex) { return employeeList; }
                  return employeeList;
            }

            public int UpdateEmployee(Employee employee)
            {
                  try
                  {
                        SqlParameter[] _sqlParam = new SqlParameter[15];
                        _sqlParam[0] = new SqlParameter("@Choice" , "U");
                        _sqlParam[1] = new SqlParameter("@Id" , employee.Id);
                        _sqlParam[2] = new SqlParameter("@FName" , employee.FName);
                        _sqlParam[3] = new SqlParameter("@LName" , employee.LName);
                        _sqlParam[4] = new SqlParameter("@Email" , employee.Email);
                        _sqlParam[5] = new SqlParameter("@PhoneNo" , employee.PhoneNo);
                        _sqlParam[6] = new SqlParameter("@DateOfBirth" , employee.DateOfBirth);
                        _sqlParam[7] = new SqlParameter("@Position" , employee.Position);
                        _sqlParam[8] = new SqlParameter("@Department" , employee.Department);
                        _sqlParam[9] = new SqlParameter("@Address" , employee.Address);
                        _sqlParam[10] = new SqlParameter("@City" , employee.City);
                        _sqlParam[11] = new SqlParameter("@State" , employee.State);
                        _sqlParam[12] = new SqlParameter("@Zipcode" , employee.Zipcode);
                        _sqlParam[13] = new SqlParameter("@JoiningDate" , employee.JoiningDate);
                        _sqlParam[14] = new SqlParameter("@Username" , "kirankos");
                        return _dbOperation.ExecuteInsertUpdateDelete(_sqlParam , ProcedureList.Proc_EmployeeMgmtAPI);
                  }
                  catch(Exception ex)
                  {
                  }
                  return 0;
            }
      }
}
