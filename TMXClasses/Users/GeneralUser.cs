using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMX.Data.Utlilties.SQL;

namespace TMXClasses.Users
{
  public class GeneralUser : BaseUser
  {
    #region Properties
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
    public GeneralUser()
    {
    }

    public GeneralUser(int Id)
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
      using (SqlDataReader reader = ExecutionHelper.ExecuteReader("dbo.GeneralUser_SelectById", parameters))
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
      using (SqlDataReader reader = ExecutionHelper.ExecuteReader("GeneralUser_InsertUpdate", GetSQLParameters()))
      {
        if (reader == null)
          return;
        if (reader.Read())
          SetProperties(reader);
      }
    }
    #endregion

    #region Static Methods
    public static GeneralUser GetUser(int id)
    {
      return new GeneralUser(id);
    }

    public static List<GeneralUser> GetAll()
    {
      GeneralUserCollection userProfiles = new GeneralUserCollection();
      userProfiles.LoadAll();
      return userProfiles;
    }

    public static GeneralUserCollection Delete(int id)
    {
      GeneralUserCollection userProfiles = new GeneralUserCollection();
      userProfiles.DeleteUser(id);
      return userProfiles;
    }
    #endregion

    #region Collection
    public class GeneralUserCollection : List<GeneralUser>
    {
      public void LoadAll()
      {
        using (SqlDataReader reader = ExecutionHelper.ExecuteReader("dbo.GeneralUser_SelectAll"))
        {
          if (reader == null)
            return;
          while (reader.Read())
          {
            GeneralUser user = new GeneralUser();
            user.SetProperties(reader);
            Add(user);
          }
        }
      }

      public void DeleteUser(int id)
      {
        List<SqlParameter> parameters = new List<SqlParameter>();
        parameters.Add(new SqlParameter("@Id", id));
        ExecutionHelper.ExecuteNonQuery("dbo.GeneralUser_Delete", parameters);
      }
    }
    #endregion
  }
}
