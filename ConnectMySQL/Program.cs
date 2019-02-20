using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConnectMySQL
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Getting Connection...");
      MySqlConnection conn = DBUtils.GetDBConnection();

      try
      {
        Console.WriteLine("Openning Connection ...");

        conn.Open();

        Console.WriteLine("Connection successful!");
      }
      catch (Exception e)
      {
        Console.WriteLine("Error: " + e.Message);
      }

      Console.Read();
    }
  }
}
