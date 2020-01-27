using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TMX.Web.Models.Requests;
using TMX.Web.Models.Requests.UserTokens;
using TMX.Web.Models.Responses;
using TMX.Web.Services;
using TMXClasses;
using System.Threading.Tasks;
using TMX.Web.Exceptions;
using TMX.Web.Models;

namespace TMX.Web.Controllers.Api
{
  [RoutePrefix("api/Users")]
  public class UsersAPIController : ApiController
  {
    [Route("Register"), HttpPost]
    public async Task<HttpResponseMessage> RegisterUser(IdentityUser model)
    {
      if (!ModelState.IsValid)
      {
        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState); //if email is NOT valid return error response 
      }
      try
      {
        IdentityUser register = UsersService.CreateUser(model.UserName, model.Email, model.PasswordHash);

        if (register != null)
        {
          UserTokensAddRequest tokensAddRequest = new UserTokensAddRequest(register.UserName, 1);
          tokensAddRequest.TokenId = UserTokensService.Add(tokensAddRequest);

          SendConfirmationEmailRequest request = new SendConfirmationEmailRequest(register.UserName, register.Email, tokensAddRequest.TokenId);
          MessagingService messaging = new MessagingService();
          await messaging.SendConfirmationEmail(request);
          //RegistrationService.RegisterUser(register);
        }
        else
        {
          return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Register wasn't successfull Please try again");
        }
        return Request.CreateResponse(new SuccessResponse());
      }

      catch (IdentityResultException iex)
      {

        ErrorResponse er = new ErrorResponse(iex.Result.Errors);
        return Request.CreateResponse(HttpStatusCode.BadRequest, er);

      }

      catch (Exception ex)
      {

        ErrorResponse er = new ErrorResponse(ex.Message);
        return Request.CreateResponse(HttpStatusCode.BadRequest, er);

      }
    }

    [Route("Login"), HttpPost]
    public HttpResponseMessage Login(LoginRequest model)
    {
      HttpResponseMessage responseMessage = null;
      BaseResponse response = null;

      if (!ModelState.IsValid)
      {
        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
      }

      ApplicationUser user = UsersService.GetUser(model.UserName);

      if (user != null)
      {
        bool emailConfirmed = UsersService.IsEmailConfirmed(model.UserName);

        if (emailConfirmed)
        {
          bool isValidLogin = false;

          isValidLogin = UsersService.IsLoginValid(model.UserName, model.Password);

          if (isValidLogin)
          {
            response = new SuccessResponse();
            responseMessage = Request.CreateResponse(response);
          }
          else
          {
            response = new ErrorResponse("Login failed! Please check if you typed in the correct Username and Password.");
            responseMessage = Request.CreateResponse(HttpStatusCode.BadRequest, response);
          }
        }
        else
        {
          response = new ErrorResponse("Please confirm your email before logging in.");
          responseMessage = Request.CreateResponse(HttpStatusCode.BadRequest, response);
        }
      }
      else
      {
        response = new ErrorResponse("Username does not exist! Please register.");
        responseMessage = Request.CreateResponse(HttpStatusCode.BadRequest, response);
      }
      return responseMessage;
    }

    [Route("UserTokens"), HttpPost]
    public HttpResponseMessage AddUserTokens(UserTokensAddRequest model)
    {
      // if the Model does not pass validation, there will be an Error response returned with errors
      if (!ModelState.IsValid)
      {
        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
      }

      ItemResponse<Guid> response = new ItemResponse<Guid>();

      response.Item = UserTokensService.Add(model);

      return Request.CreateResponse(response);
    }

    [Route("ConfirmEmail/{tokenId:guid}"), HttpPost]
    public HttpResponseMessage ConfirmEmail(Guid tokenId)
    {
      if (!ModelState.IsValid)
      {
        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
      }

      UserTokens token = UserTokensService.GetToken(tokenId);
      if (token == null || token.TokenId == null )
      {
        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Request token is invalid or expired.");
      }

      // Attempt to set AspNetUsers.EmailConfirmed value = true and insert
      // new record in Users table
      bool confirmSuccess = UserDataService.ConfirmEmail(token);
      if (!confirmSuccess)
      {
        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Failed to confirm registration.");
      }
      return Request.CreateResponse(new SuccessResponse());
    }

    [Route("SendEmail"), HttpPost]
    public HttpResponseMessage AddEmail(ForgotPasswordRequest model)
    {
      HttpResponseMessage responseMessage = null;
      BaseResponse response = null;

      if (!ModelState.IsValid)
      {
        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState); //if email is NOT valid return error response 
      }

      ApplicationUser user = UsersService.GetUserByEmail(model.Email); //grabs user email


      if (user != null)
      {
        UserTokensAddRequest token = new UserTokensAddRequest();
        token.UserName = user.UserName;
        token.TokenType = 2;
        Guid tokenId = UserTokensService.Add(token);

        SendConfirmationEmailRequest request = new SendConfirmationEmailRequest(user.UserName, user.Email, tokenId);
        MessagingService messaging = new MessagingService();
        Task t = messaging.SendForgotPasswordEmail(request); //calling it to run
      }
      else
      {
        response = new ErrorResponse("I'm sorry, but your email can't be found, Please use correct Email");
        responseMessage = Request.CreateResponse(HttpStatusCode.BadRequest, response);
        return responseMessage;
      }

      return Request.CreateResponse(user);
    }

    [Route("All"), HttpGet]
    public HttpResponseMessage GetAllUsers()
    {
      ItemsResponse<User> response = new ItemsResponse<User>();
      //response.Items = UsersService.GetAllUsers();
      return Request.CreateResponse(response);
    }

    [Route("{id:int}"), HttpGet]
    public HttpResponseMessage GetUserById(int id)
    {
      ItemResponse<User> response = new ItemResponse<User>();
      response.Item = UsersService.GetUser(id);
      return Request.CreateResponse(response);
    }

    [Route, HttpPost]
    public HttpResponseMessage AddUser(UsersInsertRequest model)
    {
      ItemResponse<int> response = new ItemResponse<int>();
      //response.Item = UsersService.CreateUpdateUser(model);
      return Request.CreateResponse(response);
    }

    [Route("{id:int}"), HttpPut]
    public HttpResponseMessage UpdateUser(UsersUpdateRequest model)
    {
      SuccessResponse response = new SuccessResponse();
      //UsersService.CreateUpdateUser(model);
      return Request.CreateResponse(response);
    }

    [Route("{id:int}"), HttpDelete]
    public HttpResponseMessage DeleteUser(int id)
    {
      SuccessResponse response = new SuccessResponse();
      //UsersService.DeleteUser(id);
      return Request.CreateResponse(response);
    }
  }
}
