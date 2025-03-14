using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace CommenReactProjectAPI.DatabaseOperation
{

      public sealed class DatabaseOperations
      {
            private static DatabaseOperations _dbOperation = null;
            private SqlConnection _sqlConnection;
            private SqlCommand _sqlCommand;
            private SqlDataAdapter _sqlAdapter;
            private DataTable _dataTable;

            public DatabaseOperations()
            {
                  _sqlConnection = new SqlConnection("Server=DESKTOP-38NM3MT\\SQLEXPRESS01;Database=CommenReactProjectAPIDB;Trusted_Connection=True;");
                  _sqlCommand = new SqlCommand();
            }
            public static DatabaseOperations GetInstance
            {
                  get
                  {
                        if(_dbOperation == null)
                        {
                              _dbOperation = new DatabaseOperations();
                        }
                        return _dbOperation;
                  }
            }
            public DataTable ExecuteDataTable(string procedureName)
            {
                  try
                  {
                        _dataTable = new DataTable();
                        _sqlCommand = new SqlCommand(procedureName , _sqlConnection);
                        _sqlCommand.CommandType = CommandType.StoredProcedure;
                        _sqlAdapter = new SqlDataAdapter(_sqlCommand);
                        _sqlAdapter.Fill(_dataTable);
                  }
                  catch(Exception ex)
                  {

                  }
                  finally
                  {
                        CloseConnection(_sqlConnection);
                  }
                  return _dataTable;
            }
            public DataTable ExecuteDataTable(SqlParameter[] parameters , string procedureName)
            {
                  try
                  {
                        _dataTable = new DataTable();
                        _sqlCommand = new SqlCommand(procedureName , _sqlConnection);
                        _sqlCommand.CommandType = CommandType.StoredProcedure;
                        _sqlCommand.Parameters.AddRange(parameters);
                        _sqlAdapter = new SqlDataAdapter(_sqlCommand);
                        _sqlAdapter.Fill(_dataTable);
                  }
                  catch(Exception ex)
                  {

                  }
                  finally
                  {
                        CloseConnection(_sqlConnection);
                  }
                  return _dataTable;
            }
            public int ExecuteInsertUpdateDelete(SqlParameter[] parameters , string procedureName)
            {
                  int procResponce = 0;
                  try
                  {
                        _dataTable = new DataTable();
                        _sqlCommand = new SqlCommand(procedureName , _sqlConnection);
                        _sqlCommand.CommandType = CommandType.StoredProcedure;
                        _sqlCommand.Parameters.AddRange(parameters);
                        OpenConnection(_sqlConnection);
                        procResponce = _sqlCommand.ExecuteNonQuery();
                        CloseConnection(_sqlConnection);
                  }
                  catch(Exception ex)
                  {
                        return procResponce;
                  }
                  finally
                  {
                        CloseConnection(_sqlConnection);
                  }
                  return procResponce;
            }
            public DataTable ExecuteFunction(SqlParameter[] parameters, string functionName)
            {
                  _dataTable = new DataTable();
                  try
                  {
                        _sqlCommand = new SqlCommand(functionName , _sqlConnection);
                        _sqlCommand.Parameters.AddRange(parameters);
                        _sqlAdapter = new SqlDataAdapter(_sqlCommand);
                        _sqlAdapter.Fill(_dataTable);
                  }
                  catch(Exception ex)
                  {

                  }
                  return _dataTable;
            }
            private static void OpenConnection(SqlConnection sqlConnection)
            {
                  if(sqlConnection.State == ConnectionState.Closed)
                  {
                        sqlConnection.Open();
                  }
            }
            private static void CloseConnection(SqlConnection sqlConnection)
            {
                  if(sqlConnection.State == ConnectionState.Open)
                  {
                        sqlConnection.Close();
                  }
            }
      }
}
