using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TMX.Data.Extensions;
using System.Data.SqlClient;
using TMX.Web.Models.Requests;
using TMXClasses;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using TMX.Web.Models;
using TMX.Web.Exceptions;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using TMX.Data.Utlilties.SQL;
using System.Security.Claims;
//using TMX.EDM;

namespace TMX.Web.Services
{
  public class UsersService : BaseService
  {
    //public static List<User> GetAllUsers()
    //{
    //  List<User> users;
    //  using (var context = new TMXDBEntities())
    //  {
    //    users = context.Users.ToList();
    //  }
    //  return users;
    //}

    public static IdentityUser CreateUser(string userName, string email, string password)
    {
      ApplicationUserManager userManager = GetUserManager();

      ApplicationUser newUser = new ApplicationUser { UserName = userName, Email = email, LockoutEnabled = false };
      IdentityResult result = null;
      try
      {
        result = userManager.Create(newUser, password);
      }
      catch
      {
        throw new IdentityResultException(result);
      }

      if (result.Succeeded)
      {
        return newUser;
      }
      else
      {
        throw new IdentityResultException(result);
      }
    }

    public static User GetUser(int id)
    {
      return User.GetUser(id);
    }

    public static bool IsEmailConfirmed(string UserName)
    {
      bool result = false;
      result = getEmailByUserName(UserName);

      //DataProvider.ExecuteNonQuery(GetConnection, "dbo.AspNetUsers_GetEmailConfirmedV2"
      //   , inputParamMapper: delegate (SqlParameterCollection paramCollection)
      //   {
      //     paramCollection.AddWithValue("@UserName", UserName);

      //     //model binding
      //     SqlParameter p = new SqlParameter("@EmailConfirmed", System.Data.SqlDbType.Bit);
      //     p.Direction = System.Data.ParameterDirection.Output;

      //     paramCollection.Add(p);

      //   }, returnParameters: delegate (SqlParameterCollection param)
      //   {
      //     result = (bool)param["@EmailConfirmed"].Value;
      //   }
      //   );
      return result;
    }

    public static bool IsLoginValid(string username, string password)
    {
      bool result = false;

      ApplicationUserManager userManager = GetUserManager();
      IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

      ApplicationUser user = userManager.Find(username, password);
      if (user != null)
      {
        ClaimsIdentity signin = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
        authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = true }, signin);
        result = true;

      }
      return result;
    }

    public static ApplicationUserManager GetUserManager()
    {
      return HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
    }

    public static ApplicationUser GetUser(string username)
    {
      ApplicationUserManager userManager = GetUserManager();
      IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

      ApplicationUser user = userManager.FindByName(username);

      return user;
    }

    public static ApplicationUser GetUserByEmail(string email)
    {
      ApplicationUserManager userManager = GetUserManager();
      IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

      ApplicationUser user = userManager.FindByEmail(email);

      return user;
    }

    public static ApplicationUser GetUserbyUserName(string userName)
    {

      ApplicationUserManager userManager = GetUserManager();
      IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

      ApplicationUser user = userManager.FindByName(userName);

      return user;
    }

    public static ApplicationUser GetUserById(string userId)
    {

      ApplicationUserManager userManager = GetUserManager();
      IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

      ApplicationUser user = userManager.FindById(userId);

      return user;
    }

    #region Private Methods
    private static bool getEmailByUserName(string userName)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      parameters.Add(new SqlParameter("@UserName", userName));
      using (SqlDataReader reader = ExecutionHelper.ExecuteReader("dbo.AspNetUsers_GetEmailConfirmed", parameters))
      {
        if (reader != null && reader.Read())
        {
          return (bool)reader.GetValue(0);
          //if(reader[reader.GetName(0)] != null)
          //  return reader.GetValue
        }
          return false;
          //SetProperties(reader);
      }
    }
    #endregion

    //public static int CreateUpdateUser(object model)
    //{
    //  User user = new User();
    //  user.Clone(model);
    //  user.Update();
    //  return user.Id;
    //}

    //public static void DeleteUser(int id)
    //{
    //  User.Delete(id);
    //}

    //private static void GetValues(SqlParameterCollection collection, dynamic model)
    //{
    //  if (model is UsersUpdateRequest)
    //  {
    //    collection.AddWithValue("@Id", model.id);
    //  }
    //  collection.AddWithValue("@fname", model.fname);
    //  collection.AddWithValue("@lname", model.lname);
    //  collection.AddWithValue("@email", model.email);
    //  collection.AddWithValue("@displayName", model.displayName);
    //  collection.AddWithValue("@city", model.city);
    //  collection.AddWithValue("@state", model.state);
    //  collection.AddWithValue("@password", model.password);
    //  collection.AddWithValue("@zipcode", model.zipcode);
    //  collection.AddWithValue("@admin", model.admin);
    //  collection.AddWithValue("@bus_id", model.bus_id);
    //  collection.AddWithValue("@bus_date", model.bus_date);
    //  collection.AddWithValue("@loginStatus", model.loginStatus);
    //  collection.AddWithValue("@about_me", model.about_me);
    //  collection.AddWithValue("@signUpDate", model.signUpDate);
    //  collection.AddWithValue("@changeDate", model.changeDate);
    //  collection.AddWithValue("@birthDate", model.birthDate);
    //  collection.AddWithValue("@facebook_id", model.facebook_id);
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