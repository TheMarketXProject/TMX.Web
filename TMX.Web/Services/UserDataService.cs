using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMX.Web.Models;
using TMXClasses;
using Microsoft.AspNet.Identity;
using System.Data.SqlClient;
using TMX.Data.Utlilties.SQL;

namespace TMX.Web.Services
{
  public class UserDataService : BaseService
  {
    public static bool ConfirmEmail(UserTokens token)
    {
      bool result = false;
      ApplicationUser appUser = UsersService.GetUserbyUserName(token.UserName);
      if (appUser != null)
      {
        updateConfirmation(token);

        User user = new User
        {
          Email = appUser.Email,
          IsActive = true
        };
        user.Add();
        UserTokens.Delete(token.TokenId);
        result = true;
      }
      return result;
    }

    private static void updateConfirmation(UserTokens token)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      parameters.Add(new SqlParameter("@EmailConfirmed", true));
      parameters.Add(new SqlParameter("@UserName", token.UserName));
      ExecutionHelper.ExecuteNonQuery("dbo.AspNetUsers_UpdateEmailConfirmed", parameters);
    }
  }
}