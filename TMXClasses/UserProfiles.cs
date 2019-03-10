using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMX.Data.Utlilties.SQL;

namespace TMXClasses
{
  public class UserProfiles : BaseClass
  {
    #region Properties
    public int Id { get; set; }
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DisplayName { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public int Zipcode { get; set; }
    public string About { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }
    #endregion

    #region Constructors
    public UserProfiles()
    {
    }

    public UserProfiles(int Id)
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
      using (SqlDataReader reader = ExecutionHelper.ExecuteReader("dbo.UserProfiles_SelectById", parameters))
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
      propertiesToOmit.Add("DateCreated");
      propertiesToOmit.Add("DateModified");
      using (SqlDataReader reader = ExecutionHelper.ExecuteReader("UserProfiles_InsertUpdate", GetSQLParameters()))
      {
        if (reader == null)
          return;
        if (reader.Read())
          SetProperties(reader);
      }
    }
    #endregion

    #region Static Methods
    public static UserProfiles GetUser(int id)
    {
      return new UserProfiles(id);
    }

    public static List<UserProfiles> GetAll()
    {
      UserProfilesCollection userProfiles = new UserProfilesCollection();
      userProfiles.LoadAll();
      return userProfiles;
    }

    public static UserProfilesCollection Delete(int id)
    {
      UserProfilesCollection userProfiles = new UserProfilesCollection();
      userProfiles.DeleteUser(id);
      return userProfiles;
    }
    #endregion

    #region Collection
    public class UserProfilesCollection : List<UserProfiles>
    {
      public void LoadAll()
      {
        using (SqlDataReader reader = ExecutionHelper.ExecuteReader("dbo.UserProfiles_SelectAll"))
        {
          if (reader == null)
            return;
          while (reader.Read())
          {
            UserProfiles user = new UserProfiles();
            user.SetProperties(reader);
            Add(user);
          }
        }
      }

      public void DeleteUser(int id)
      {
        List<SqlParameter> parameters = new List<SqlParameter>();
        parameters.Add(new SqlParameter("@Id", id));
        ExecutionHelper.ExecuteNonQuery("dbo.UserProfiles_Delete", parameters);
      }
    }
    #endregion
  }
}
