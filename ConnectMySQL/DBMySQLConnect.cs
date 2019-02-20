using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConnectMySQL
{
  public class DBMySQLConnect
  {
    private MySqlConnection connection;
    private string server;
    private string database;
    private string uid;
    private string password;

    public DBMySQLConnect()
    {
      Initialize();
    }

    //Initialize values
    private void Initialize()
    {
      server = "localhost";
      database = "marketx";
      uid = "root";
      password = "";
      string connectionString;
      connectionString = "SERVER=" + server + ";" + "DATABASE=" +
  database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

      connection = new MySqlConnection(connectionString);
    }

    public static MySqlConnection GetDBConnection(string host, string database, string username, string password)
    {
      //string host = "localhost";
      //string db = "marketx";
      //string username = "root";
      //string pass = "";
      // Connection String.
      string connString = "Server=" + host + ";Database=" + database + ";User Id=" + username + ";password=" + password;

      MySqlConnection conn = new MySqlConnection(connString);

      return conn;
    }

    //open connection to database
    private bool OpenConnection()
    {
      try
      {
        connection.Open();
        return true;
      }
      catch (MySqlException ex)
      {
        //When handling errors, you can your application's response based 
        //on the error number.
        //The two most common error numbers when connecting are as follows:
        //0: Cannot connect to server.
        //1045: Invalid user name and/or password.
        switch (ex.Number)
        {
          case 0:
            Console.WriteLine("Cannot connect to server.  Contact administrator");
            break;

          case 1045:
            Console.WriteLine("Invalid username/password, please try again");
            break;
        }
        return false;
      }
    }

    //Close connection
    private bool CloseConnection()
    {
      try
      {
        connection.Close();
        return true;
      }
      catch (MySqlException ex)
      {
        Console.WriteLine(ex.Message);
        return false;
      }
    }

    //Insert statement
    public void Insert()
    {
    }

    //Update statement
    public void Update()
    {
    }

    //Delete statement
    public void Delete()
    {
    }

    ////Select statement
    //public List<string>[] Select()
    //{
    //}

    ////Count statement
    //public int Count()
    //{
    //}

    //Backup
    public void Backup()
    {
    }

    //Restore
    public void Restore()
    {
    }
  }
}
