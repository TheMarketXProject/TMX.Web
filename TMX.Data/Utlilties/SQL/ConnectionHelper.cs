using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMX.Data.Utlilties.SQL
{
  public class ConnectionHelper
  {
    public static bool IsReadingOneRowSuccessful(SqlDataReader reader)
    {
      return (reader != null && reader.Read());
    }

    public static string GetTMXConnectionString()
    {
      return GetConnectionString("DefaultConnection");
    }

    public static string GetConnectionString(string configName)
    {
      if (ConfigurationManager.ConnectionStrings[configName] != null)
        return ConfigurationManager.ConnectionStrings[configName].ConnectionString;
      return ConfigurationManager.AppSettings[configName];
    }
  }
}
