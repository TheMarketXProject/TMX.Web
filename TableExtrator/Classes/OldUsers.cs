using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMX.Data.Utlilties.SQL;
using TMXClasses;

namespace TableExtrator.Classes
{
  public class OldUsers : BaseClass
  {
    #region Properties
    public int id { get; set; }
    public string fname { get; set; }
    public string lname { get; set; }
    public string email { get; set; }
    public string displayName { get; set; }
    public string city { get; set; }
    public string state { get; set; }
    public string password { get; set; }
    public int zipcode { get; set; }
    public string admin { get; set; }
    public string bus_id { get; set; }
    public string bus_date { get; set; }
    public string loginStatus { get; set; }
    public string about_me { get; set; }
    public string signUpDate { get; set; }
    public string changeDate { get; set; }
    public string birthDate { get; set; }
    public string facebook_id { get; set; }
    #endregion

    #region Constructors
    public OldUsers()
    {
    }

    public OldUsers(int Id)
    {
      id = Id;
      Load();
    }
    #endregion

    #region Public Methods
    public void Load()
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      parameters.Add(new SqlParameter("@Id", id));
      using (SqlDataReader reader = ExecutionHelper.ExecuteReader("dbo.OldUsers_SelectById", parameters))
      {
        if (reader == null)
          return;
        if (reader.Read())
          SetProperties(reader);
      }
    }

    public void Update()
    {
      using (SqlDataReader reader = ExecutionHelper.ExecuteReader("dbo.OldUsers_InsertUpdate", GetSQLParameters()))
      {
        if (reader == null)
          return;
        if (reader.Read())
          SetProperties(reader);
      }
    }
    #endregion

    #region Static Methods
    public static OldUsers GetUser(int id)
    {
      return new OldUsers(id);
    }

    public static List<OldUsers> GetAll()
    {
      OldUsersCollection OldUsers = new OldUsersCollection();
      OldUsers.LoadAll();
      return OldUsers;
    }

    public static OldUsersCollection Delete(int id)
    {
      OldUsersCollection OldUsers = new OldUsersCollection();
      OldUsers.DeleteUser(id);
      return OldUsers;
    }
    #endregion

    #region Collection
    public class OldUsersCollection : List<OldUsers>
    {
      public void LoadAll()
      {
        using (SqlDataReader reader = ExecutionHelper.ExecuteReader("dbo.OldUsers_SelectAll"))
        {
          if (reader == null)
            return;
          while (reader.Read())
          {
            OldUsers user = new OldUsers();
            user.SetProperties(reader);
            Add(user);
          }
        }
      }

      public void DeleteUser(int id)
      {
        List<SqlParameter> parameters = new List<SqlParameter>();
        parameters.Add(new SqlParameter("@Id", id));
        ExecutionHelper.ExecuteNonQuery("dbo.OldUsers_Delete", parameters);
      }
    }
    #endregion
  }
}
