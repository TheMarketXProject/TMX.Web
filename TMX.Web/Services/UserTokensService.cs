using System;
using System.Collections.Generic;
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
  }
}