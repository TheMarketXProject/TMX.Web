using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TMX.Web.Models.Requests.UserTokens;
using TMXClasses;

namespace TMX.Web.Services
{
  public class UserTokensService : BaseService
  {
    public static Guid Add(object model)
    {
      UserTokens token = new UserTokens();
      token.Clone(model);
      token.Add();
      return token.TokenId;
    }

    public static UserTokens GetToken(Guid id)
    {
      return new UserTokens(id);
    }

    public static bool IsValid(Guid id)
    {
      UserTokens token = new UserTokens(id);
      if (token.TokenId == null) return false;
      else return true;
    }
  }
}