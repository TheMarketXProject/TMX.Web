using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TMX.Data;
using TMX.Data.Utlilties.SQL;
using TMXClasses;

namespace TMXClasses
{
  public class Users : BaseClass
  {
    #region Properties
    public int Id { get; set; }
    public string UserType { get; set; }
    public bool IsActive { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime SignUpDate { get; set; }
    public DateTime LastLoginDate { get; set; }
    #endregion

    #region Constructors
    public Users()
    {
    }

    public Users(int Id)
    {
      this.Id = Id;
      Load();
    }
    #endregion

    #region Public Methods
    public void Load()
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      parameters.Add(new SqlParameter("@Id", Id));
      using (SqlDataReader reader = ExecutionHelper.ExecuteReader("dbo.Users_SelectById", parameters))
      {
        if (reader == null)
          return;
        if (reader.Read())
          SetProperties(reader);
      }
    }

    public void Update()
    {
      ArrayList propertiesToOmit = new ArrayList();
      using (SqlDataReader reader = ExecutionHelper.ExecuteReader("dbo.Users_InsertUpdate", GetSQLParameters()))
      {
        if (reader == null)
          return;
        if (reader.Read())
          SetProperties(reader);
      }
    }
    #endregion

    #region Static Methods
    public static Users GetUser(int id)
    {
      return new Users(id);
    }

    public static List<Users> GetAll()
    {
      UsersCollection users = new UsersCollection();
      users.LoadAll();
      return users;
    }

    public static UsersCollection Delete(int id)
    {
      UsersCollection users = new UsersCollection();
      users.DeleteUser(id);
      return users;
    }
    #endregion

    #region Collection
    public class UsersCollection : List<Users>
    {
      public void LoadAll()
      {
        using (SqlDataReader reader = ExecutionHelper.ExecuteReader("dbo.Users_SelectAll"))
        {
          if (reader == null)
            return;
          while (reader.Read())
          {
            Users user = new Users();
            user.SetProperties(reader);
            Add(user);
          }
        }
      }

      public void DeleteUser(int id)
      {
        List<SqlParameter> parameters = new List<SqlParameter>();
        parameters.Add(new SqlParameter("@Id", id));
        ExecutionHelper.ExecuteNonQuery("dbo.Users_Delete", parameters);
      }
    }
    #endregion
  }
}