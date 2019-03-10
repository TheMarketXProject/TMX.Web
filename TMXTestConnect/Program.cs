using TMX.Web.Models.Responses;
using TMX.Web.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using TMXTestConnect.Providers;
using TMX.Data;
using TMXClasses;

namespace TMXTestConnect
{
  class Program
  {
    static void Main(string[] args)
    {
      using (SqlConnection conn = DBConnect.GetConnection())
      {
        try
        {
          //conn.Open();
          Console.WriteLine("Connection Open!");

          //List<Users> users = new List<Users>();
          //users = GetAllUsers();
          //foreach (Users user in users)
          //{
          //  Console.WriteLine($"User {user.id}: {user.fname} {user.lname}");
          //}
        }
        catch (SqlException ex)
        {
          Console.WriteLine(ex.Message);
        }
      }
    }

    //public static List<Users> GetAllUsers()
    //{
    //  List<Users> list = null;

    //  DataProvider.Instance.ExecuteCmd(DBConnect.GetConnection, "dbo.users_SelectAll",
    //      inputParamMapper: null,
    //      map: delegate (IDataReader reader, short set)
    //      {
    //        Users item = MapUsers(reader);
    //        if (list == null)
    //        {
    //          list = new List<Users>();
    //        }

    //        list.Add(item);
    //      });

    //  return list;
    //}

    //private static Users MapUsers(IDataReader reader)
    //{
    //  Users item = new Users();
    //  int startingIndex = 0;

    //  item.id = reader.GetSafeInt32(startingIndex++);
    //  item.fname = reader.GetSafeString(startingIndex++);
    //  item.lname = reader.GetSafeString(startingIndex++);
    //  item.email = reader.GetSafeString(startingIndex++);
    //  item.displayName = reader.GetSafeString(startingIndex++);
    //  item.city = reader.GetSafeString(startingIndex++);
    //  item.state = reader.GetSafeString(startingIndex++);
    //  item.password = reader.GetSafeString(startingIndex++);
    //  item.zipcode = reader.GetSafeInt32(startingIndex++);
    //  item.admin = reader.GetSafeString(startingIndex++);
    //  item.bus_id = reader.GetSafeString(startingIndex++);
    //  item.bus_date = reader.GetSafeString(startingIndex++);
    //  item.loginStatus = reader.GetSafeString(startingIndex++);
    //  item.about_me = reader.GetSafeString(startingIndex++);
    //  item.signUpDate = reader.GetSafeString(startingIndex++);
    //  item.changeDate = reader.GetSafeString(startingIndex++);
    //  item.birthDate = reader.GetSafeString(startingIndex++);
    //  item.facebook_id = reader.GetSafeString(startingIndex++);

    //  return item;
    //}
  }
}
