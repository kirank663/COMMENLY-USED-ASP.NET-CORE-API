using CommenReactProjectAPI.CommenFunction;
using CommenReactProjectAPI.DatabaseOperation;
using CommenReactProjectAPI.IModelRepository;
using CommenReactProjectAPI.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace CommenReactProjectAPI.ModelRepository
{
      public class UserRepository : IUserRepository
      {
            DatabaseOperations _dbOperation = DatabaseOperations.GetInstance; 
            public int AddUser(User user)
            {
                  try
                  {
                        SqlParameter[] _sqlParam = new SqlParameter[6];
                        _sqlParam[0] = new SqlParameter("@choice" , "I");
                        _sqlParam[1] = new SqlParameter("@name" , user.Name);
                        _sqlParam[2] = new SqlParameter("@email" , user.Email);
                        _sqlParam[3] = new SqlParameter("@phoneNo" , user.Phone);
                        _sqlParam[4] = new SqlParameter("@city" , user.City);
                        _sqlParam[5] = new SqlParameter("@username" , "kirankoshti");
                        return _dbOperation.ExecuteInsertUpdateDelete(_sqlParam , ProcedureList.Proc_UserDetailsAPI);
                  }
                  catch(Exception ex)
                  {
                  }
                  return 0;
            }

            public int DeleteUser(int id)
            {
                  try
                  {
                        SqlParameter[] _sqlParam = new SqlParameter[3];
                        _sqlParam[0] = new SqlParameter("@choice" , "D");
                        _sqlParam[1] = new SqlParameter("@Id" , id);
                        _sqlParam[2] = new SqlParameter("@username" , "kirankoshti");
                        return _dbOperation.ExecuteInsertUpdateDelete(_sqlParam , ProcedureList.Proc_UserDetailsAPI);
                  }
                  catch(Exception ex)
                  {
                  }
                  return 0;
            }

            public List<User> GetUserDetailsById(int id)
            {
                  List<User> _userList = new List<User>();
                  try
                  {
                        SqlParameter[] _sqlParam = new SqlParameter[3];
                        _sqlParam[0] = new SqlParameter("@choice" , "B");
                        _sqlParam[1] = new SqlParameter("@Id" , id);
                        _sqlParam[2] = new SqlParameter("@username" , "kirankoshti");
                        _userList = CommenFunctions.ConvertDataTableToList<User>(_dbOperation.ExecuteDataTable(_sqlParam , ProcedureList.Proc_UserDetailsAPI));
                  }
                  catch(Exception ex)
                  {
                        return _userList;
                  }
                  return _userList;
            }

            public List<User> GetUserList()
            {
                  List<User> _userList = new List<User>();
                  try
                  {
                        SqlParameter[] _sqlParam = new SqlParameter[2];
                        _sqlParam[0] = new SqlParameter("@choice" , "S");
                        _sqlParam[1] = new SqlParameter("@username" , "kirankoshti");
                        _userList = CommenFunctions.ConvertDataTableToList<User>(_dbOperation.ExecuteDataTable(_sqlParam , ProcedureList.Proc_UserDetailsAPI));
                  }
                  catch(Exception ex)
                  {
                        return _userList;
                  }
                  return _userList;
            }

            public int UpdateUser(User user)
            {
                  try
                  {
                        SqlParameter[] _sqlParam = new SqlParameter[7];
                        _sqlParam[0] = new SqlParameter("@choice" , "U");
                        _sqlParam[1] = new SqlParameter("@Id" , user.Id);
                        _sqlParam[2] = new SqlParameter("@name" , user.Name);
                        _sqlParam[3] = new SqlParameter("@email" , user.Email);
                        _sqlParam[4] = new SqlParameter("@phoneNo" , user.Phone);
                        _sqlParam[5] = new SqlParameter("@city" , user.City);
                        _sqlParam[6] = new SqlParameter("@username" , "kirankoshti");
                        return _dbOperation.ExecuteInsertUpdateDelete(_sqlParam , ProcedureList.Proc_UserDetailsAPI);
                  }
                  catch(Exception ex)
                  {
                  }
                  return 0;
            }
            public bool IsUserExistIntoTable(string phoneNo,string email)
            {
                  try
                  {
                        SqlParameter[] _sqlParam = new SqlParameter[2];
                        _sqlParam[0] = new SqlParameter("@phoneNo" , phoneNo);
                        _sqlParam[1] = new SqlParameter("@email" , email);
                        var _dataTable = _dbOperation.ExecuteFunction(_sqlParam, "SELECT * FROM dbo.Check_IfUserIsAlreadyExist(@phoneNo,@email)");
                        if(_dataTable.Rows.Count > 0)
                        {
                              return true;
                        }
                        else
                        {
                              return false;
                        }
                  }
                  catch(Exception ex)
                  {
                  }
                  return false;
            }
      }
}
