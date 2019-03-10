using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMXTestConnect.Providers;

namespace TMXTestConnect
{
  public static class DBConnect
  {
    public static IDao DataProvider
    {
      get { return TMXTestConnect.DataProvider.Instance; }
    }

    public static SqlConnection GetConnection()
    {
      string dataSource = "(local)";
      string dataBase = "marketxTestDB";
      string connectionString = "Data Source =" + dataSource + ";Initial Catalog=" + dataBase + ";Integrated Security=SSPI;Database=" + dataBase + ";";
      return new SqlConnection(connectionString);
    }
  }
}
