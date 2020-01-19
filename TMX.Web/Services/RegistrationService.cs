using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using TMX.Web.Models.Requests;
using TMX.Web.Models.Requests.UserTokens;

namespace TMX.Web.Services
{
  public class RegistrationService : BaseService
  {
    public static void RegisterUser(IdentityUser register)
    {
      //IdentityUser register = UsersService.CreateUser(model.UserName, model.Email, model.PasswordHash);

      //if (register != null)
      //{
      UserTokensAddRequest tokensAddRequest = new UserTokensAddRequest(register.UserName, 1);
      tokensAddRequest.TokenId = UserTokensService.Add(tokensAddRequest);

      SendConfirmationEmailRequest request = new SendConfirmationEmailRequest(register.UserName, register.Email, tokensAddRequest.TokenId);
      MessagingService messaging = new MessagingService();
      Task t = messaging.SendConfirmationEmail(request);
      //}
      //else
      //{
      //  throw new Exception("Register wasn't successfull Please try again");
      //    //Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Register wasn't successfull Please try again");
      //}
      //return Request.CreateResponse(register);
    }
  }
}