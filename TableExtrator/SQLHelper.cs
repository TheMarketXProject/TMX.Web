using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMX.Data;

namespace TableExtrator
{
  public class SQLHelper
  {
    public static SqlDataReader ExecuteQuery(string ProcedureName)
    {
      SqlConnection Conn = new SqlConnection("Data Source=(local);Initial Catalog=marketxTestDB;Integrated Security=SSPI;Database=marketxTestDB;");
      SqlCommand Comm = new SqlCommand();
      SqlDataReader rdr = null;

      try
      {
        Conn.Open();
        Comm.Connection = Conn;
        Comm.CommandText = ProcedureName;
        Comm.CommandType = CommandType.Text;
        rdr = Comm.ExecuteReader(CommandBehavior.CloseConnection);
      }
      catch (Exception ex)
      {
        ErrorLog EL = new ErrorLog(ex);
        EL.UserID = 0;
        EL.LogError();
        Conn.Close();
        Comm.Dispose();
        throw new Exception(ex.ToString());
      }

      return rdr;
    }
  }
}
