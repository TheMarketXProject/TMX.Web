using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using TMX.Data.Utlilties.SQL;

namespace TMXClasses
{
  public class User : BaseClass
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
    public User()
    {
    }

    public User(int Id)
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

    public void Add()
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      parameters.Add(new SqlParameter("@Email", Email));
      parameters.Add(new SqlParameter("@IsActive", IsActive));
      ExecutionHelper.ExecuteReader("dbo.Users_Insert", parameters);
      //using (SqlDataReader reader = ExecutionHelper.ExecuteReader("dbo.Users_Insert", GetSQLParameters()))
      //{
      //  if (reader == null)
      //    return;
      //  if (reader.Read())
      //    SetProperties(reader);
      //}
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
    public static User GetUser(int id)
    {
      return new User(id);
    }

    public static List<User> GetAll()
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
    public class UsersCollection : List<User>
    {
      public void LoadAll()
      {
        using (SqlDataReader reader = ExecutionHelper.ExecuteReader("dbo.Users_SelectAll"))
        {
          if (reader == null)
            return;
          while (reader.Read())
          {
            User user = new User();
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