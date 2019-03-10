using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace TMX.Data.Utlilties.SQL
{
  public class ExecutionHelper
  {
    #region Public Static Methods
    public static void BulkInsert(DataTable dataTable, string databaseTableName, string connectionString)
    {
      using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(connectionString))
      {
        sqlBulkCopy.DestinationTableName = databaseTableName;
        sqlBulkCopy.BatchSize = 100;

        try
        {
          foreach (DataColumn column in dataTable.Columns)
          {
            //Avoid attempting an insert of identity columns
            if (column.ColumnName.ToLower() == "id" || column.ColumnName.ToLower() == "oid")
              continue;
            sqlBulkCopy.ColumnMappings.Add(column.ColumnName, column.ColumnName);
          }
          sqlBulkCopy.WriteToServer(dataTable);
          sqlBulkCopy.Close();
        }
        catch (Exception ex)
        {
          sqlBulkCopy.Close();
          throw new Exception(ex.ToString());
        }
      }
    }

    public static DataSet ExecuteDataset(string v1, string v2)
    {
      throw new NotImplementedException();
    }

    public static void ExecuteWithoutLogging(string procedureName, List<SqlParameter> parameters, string connectionString)
    {
      SqlConnection Conn = new SqlConnection(connectionString);
      SqlCommand Comm = new SqlCommand();

      try
      {
        Conn.Open();
        Comm.Connection = Conn;
        Comm.CommandText = procedureName;
        Comm.CommandType = CommandType.StoredProcedure;
        foreach (SqlParameter Param in parameters)
          Comm.Parameters.Add(Param);
        Comm.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        throw new Exception(ex.ToString());
      }
      finally
      {
        Conn.Close();
        Comm.Dispose();
      }
    }

    public static string GetConnectionString()
    {
      if (ConfigurationManager.ConnectionStrings["DefaultConnection"] != null)
        return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
      else
        return ConfigurationManager.AppSettings["DefaultConnection"];
    }

    public static SqlDataReader ExecuteReader(string ProcedureName, List<SqlParameter> Params)
    {
      return ExecuteReader(ProcedureName, Params, GetConnectionString());
    }

    public static SqlDataReader ExecuteReader(string ProcedureName)
    {
      return ExecuteReader(ProcedureName, new List<SqlParameter>(), GetConnectionString());
    }

    public static SqlDataReader ExecuteReader(string ProcedureName, List<SqlParameter> Params, string ConnectionString)
    {
      SqlConnection Conn = new SqlConnection(ConnectionString ?? "Data Source=(local);Initial Catalog=marketxTestDB;Integrated Security=SSPI;Database=marketxTestDB;");
      SqlCommand Comm = new SqlCommand();
      SqlDataReader rdr = null;

      try
      {
        Conn.Open();
        Comm.Connection = Conn;
        Comm.CommandText = ProcedureName;
        Comm.CommandType = CommandType.StoredProcedure;
        foreach (SqlParameter Param in Params)
        {
          Comm.Parameters.Add(Param);
        }
        rdr = Comm.ExecuteReader(CommandBehavior.CloseConnection);
      }
      catch (Exception ex)
      {
        ErrorLog EL = new ErrorLog(ex);
        EL.URL = BuildSQLStringFromParams(ProcedureName, Params);
        EL.UserID = 0;
        EL.LogError();
        Conn.Close();
        Comm.Dispose();
        throw new Exception(ex.ToString());
      }

      return rdr;
    }

    public static string BuildSQLStringFromParams(string ProcedureName, List<SqlParameter> Params)
    {
      StringBuilder result = new StringBuilder();
      result.Append("EXEC " + ProcedureName + " ");
      foreach (SqlParameter Param in Params)
      {
        if (Param.Value == null)
          continue;
        if (Param.SqlDbType == SqlDbType.VarChar || Param.SqlDbType == SqlDbType.NVarChar || Param.SqlDbType == SqlDbType.DateTime)
          result.Append(Param.ToString() + "='" + Param.Value.ToString() + "',");
        else if (Param.SqlDbType == SqlDbType.Bit)
        {
          int value = 0;
          if (Boolean.Parse(Param.Value.ToString()))
            value = 1;
          result.Append(Param.ToString() + "=" + value.ToString() + ",");
        }
        else
          result.Append(Param.ToString() + "=" + Param.Value.ToString() + ",");
      }
      //Remove the ending comma
      result.Remove(result.Length - 1, 1);
      return result.ToString();
    }

    public static void ExecuteNonQuery(string procedureName, List<SqlParameter> parameters)
    {
      ExecuteNonQuery(procedureName, parameters, GetConnectionString());
    }

    public static void ExecuteNonQuery(string procedureName, List<SqlParameter> parameters, string connectionString)
    {
      SqlConnection Conn = new SqlConnection(connectionString);
      SqlCommand Comm = new SqlCommand();

      try
      {
        Conn.Open();
        Comm.Connection = Conn;
        Comm.CommandText = procedureName;
        Comm.CommandType = CommandType.StoredProcedure;
        foreach (SqlParameter Param in parameters)
        {
          Comm.Parameters.Add(Param);
        }
        Comm.ExecuteNonQuery();
      }
      catch (System.Exception ex)
      {
        ErrorLog EL = new ErrorLog(ex);
        EL.URL = BuildSQLStringFromParams(procedureName, parameters);
        EL.UserID = 0;
        EL.LogError();
        throw new Exception(ex.ToString());
      }
      finally
      {
        Conn.Close();
        Comm.Dispose();
      }
    }

    public static DataSet ExecuteDataset(string ProcedureName, List<SqlParameter> Params)
    {
      SqlConnection Conn = new SqlConnection(GetConnectionString());
      SqlCommand Comm = new SqlCommand();
      DataSet dsGeneric = new DataSet();
      SqlDataAdapter dapt = new SqlDataAdapter(Comm);

      try
      {
        Conn.Open();
        Comm.Connection = Conn;
        Comm.CommandText = ProcedureName;
        Comm.CommandType = CommandType.StoredProcedure;
        foreach (SqlParameter Param in Params)
        {
          Comm.Parameters.Add(Param);
        }
        dapt.Fill(dsGeneric);
      }
      catch (Exception ex)
      {
        ErrorLog EL = new ErrorLog(ex);
        EL.URL = BuildSQLStringFromParams(ProcedureName, Params);
        EL.UserID = 0;
        EL.LogError();
        Conn.Close();
        Comm.Dispose();
        throw new Exception(ex.ToString());
      }
      finally
      {
        Conn.Close();
        Comm.Dispose();
      }
      if (dsGeneric.Tables.Count < 1)
        dsGeneric.Tables.Add(new DataTable());

      return dsGeneric;
    }

    public static DataSet ExecuteDataset(string procedureName, List<SqlParameter> Params, string ConnectionString)
    {
      SqlConnection connection = new SqlConnection(ConnectionString);
      SqlCommand command = new SqlCommand();
      DataSet dsGeneric = new DataSet();
      SqlDataAdapter dapt = new SqlDataAdapter(command);

      try
      {
        connection.Open();
        command.Connection = connection;
        command.CommandText = procedureName;
        command.CommandType = CommandType.StoredProcedure;
        foreach (SqlParameter Param in Params)
        {
          command.Parameters.Add(Param);
        }
        dapt.Fill(dsGeneric);
      }
      catch (Exception ex)
      {
        ErrorLog EL = new ErrorLog(ex);
        EL.URL = BuildSQLStringFromParams(procedureName, Params);
        EL.UserID = 0;
        EL.LogError();
        connection.Close();
        command.Dispose();
        throw new Exception(ex.ToString());
      }
      finally
      {
        connection.Close();
        command.Dispose();
      }
      if (dsGeneric.Tables.Count < 1)
        dsGeneric.Tables.Add(new DataTable());

      return dsGeneric;
    }

    public static Object ExecuteScalar(string ProcedureName, List<SqlParameter> Params)
    {
      return ExecuteScalar(ProcedureName, Params, GetConnectionString());
    }

    public static Object ExecuteScalar(string ProcedureName)
    {
      return ExecuteScalar(ProcedureName, new List<SqlParameter>(), GetConnectionString());
    }

    public static Object ExecuteScalar(string ProcedureName, List<SqlParameter> Params, string ConnectionString)
    {
      SqlConnection Conn = new SqlConnection(ConnectionString);
      SqlCommand Comm = new SqlCommand();
      Object obj = null;

      try
      {
        Conn.Open();
        Comm.Connection = Conn;
        Comm.CommandText = ProcedureName;
        Comm.CommandType = CommandType.StoredProcedure;
        foreach (SqlParameter Param in Params)
        {
          Comm.Parameters.Add(Param);
        }
        obj = Comm.ExecuteScalar();
      }
      catch (Exception ex)
      {
        //ErrorLog EL = new ErrorLog(ex);
        //EL.URL = BuildSQLStringFromParams(ProcedureName, Params);
        //EL.UserID = 0;
        //EL.LogError();
        //Conn.Close();
        //Comm.Dispose();
        throw new Exception(ex.ToString());
      }
      finally
      {
        Conn.Close();
        Comm.Dispose();
      }

      return obj;
    }

    public static void CloseReader(SqlDataReader reader)
    {
      try
      {
        reader.Close();
      }
      catch (Exception ex)
      {
        throw new Exception(ex.ToString());
      }
    }
    #endregion
  }
}
