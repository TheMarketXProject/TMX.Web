using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectMySQL
{
  public class DBUtils
  {
    public static MySqlConnection GetDBConnection()
    {
      string server = "localhost";
      string database = "marketx";
      string uid = "root";
      string password = "";

      return DBMySQLConnect.GetDBConnection(server, database, uid, password);
    }
  }
}
