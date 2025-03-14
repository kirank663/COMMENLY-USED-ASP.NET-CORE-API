using CommenReactProjectAPI.CommenFunction;
using CommenReactProjectAPI.DatabaseOperation;
using CommenReactProjectAPI.IModelRepository;
using CommenReactProjectAPI.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace CommenReactProjectAPI.ModelRepository
{
      public class StudentRepository : IStudentRepository
      {
            DatabaseOperations _dbOperation = DatabaseOperations.GetInstance;
            public int AddStudent(Student student)
            {
                  try
                  {
                        SqlParameter[] _sqlParam = new SqlParameter[6];
                        _sqlParam[0] = new SqlParameter("@choice" , "I");
                        _sqlParam[1] = new SqlParameter("@nic" , student.nic);
                        _sqlParam[2] = new SqlParameter("@stdName" , student.name);
                        _sqlParam[3] = new SqlParameter("@stdAddress" , student.address);
                        _sqlParam[4] = new SqlParameter("@stdContactNo" , student.contactNo);             
                        _sqlParam[5] = new SqlParameter("@username" , "kirankos");
                        return _dbOperation.ExecuteInsertUpdateDelete(_sqlParam , ProcedureList.Proc_StudentMgmtAPI);
                  }
                  catch(Exception ex)
                  {
                  }
                  return 0;
            }

            public int DeleteStudent(int id)
            {
                  try
                  {
                        SqlParameter[] _sqlParam = new SqlParameter[3];
                        _sqlParam[0] = new SqlParameter("@choice" , "D");
                        _sqlParam[1] = new SqlParameter("@Id" , id);
                        _sqlParam[2] = new SqlParameter("@username" , "kirankos");
                        return _dbOperation.ExecuteInsertUpdateDelete(_sqlParam , ProcedureList.Proc_StudentMgmtAPI);
                  }
                  catch(Exception ex)
                  {
                  }
                  return 0;
            }

            public List<Student> GetStudentById(int id)
            {
                  List<Student> studentList = new List<Student>();
                  try
                  {
                        SqlParameter[] _sqlParam = new SqlParameter[3];
                        _sqlParam[0] = new SqlParameter("@choice" , "B");
                        _sqlParam[1] = new SqlParameter("@Id" , id);
                        _sqlParam[2] = new SqlParameter("@username" , "kirankos");
                        studentList = CommenFunctions.ConvertDataTableToList<Student>(_dbOperation.ExecuteDataTable(_sqlParam , ProcedureList.Proc_StudentMgmtAPI));
                  }
                  catch(Exception ex)
                  {
                        return studentList;
                  }
                  return studentList;
            }

            public List<Student> GetStudentList()
            {
                  List<Student> studentList = new List<Student>();
                  try
                  {
                        SqlParameter[] _sqlParam = new SqlParameter[2];
                        _sqlParam[0] = new SqlParameter("@choice" , "S");
                        _sqlParam[1] = new SqlParameter("@username" , "kirankos");
                        studentList = CommenFunctions.ConvertDataTableToList<Student>(_dbOperation.ExecuteDataTable(_sqlParam , ProcedureList.Proc_StudentMgmtAPI));
                  }
                  catch(Exception ex)
                  {
                        return studentList;
                  }
                  return studentList;
            }

            public int UpdateStudent(Student student)
            {
                  try
                  {
                        SqlParameter[] _sqlParam = new SqlParameter[7];
                        _sqlParam[0] = new SqlParameter("@choice" , "U");
                        _sqlParam[1] = new SqlParameter("@Id" , student.stdId);
                        _sqlParam[2] = new SqlParameter("@nic" , student.nic);
                        _sqlParam[3] = new SqlParameter("@stdName" , student.name);
                        _sqlParam[4] = new SqlParameter("@stdAddress" , student.address);
                        _sqlParam[5] = new SqlParameter("@stdContactNo" , student.contactNo);
                        _sqlParam[6] = new SqlParameter("@username" , "kirankos");
                        return _dbOperation.ExecuteInsertUpdateDelete(_sqlParam , ProcedureList.Proc_StudentMgmtAPI);
                  }
                  catch(Exception ex)
                  {
                  }
                  return 0;
            }
      }
}
