using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TMX.Web.Models.Requests;
using TMX.Web.Models.Responses;
using TMX.Web.Services;
using TMXClasses;

namespace TMX.Web.Controllers.Api
{
  [RoutePrefix("api/Users")]
  public class UsersAPIController : ApiController
  {
    [Route("All"), HttpGet]
    public HttpResponseMessage GetAllUsers()
    {
      ItemsResponse<Users> response = new ItemsResponse<Users>();
      response.Items = UsersService.GetAllUsers();
      return Request.CreateResponse(response);
    }

    [Route("{id:int}"), HttpGet]
    public HttpResponseMessage GetUserById(int id)
    {
      ItemResponse<Users> response = new ItemResponse<Users>();
      response.Item = UsersService.GetUser(id);
      return Request.CreateResponse(response);
    }

    [Route, HttpPost]
    public HttpResponseMessage AddUser(UsersInsertRequest model)
    {
      ItemResponse<int> response = new ItemResponse<int>();
      response.Item = UsersService.CreateUpdateUser(model);
      return Request.CreateResponse(response);
    }

    [Route("{id:int}"), HttpPut]
    public HttpResponseMessage UpdateUser(UsersUpdateRequest model)
    {
      SuccessResponse response = new SuccessResponse();
      UsersService.CreateUpdateUser(model);
      return Request.CreateResponse(response);
    }

    [Route("{id:int}"), HttpDelete]
    public HttpResponseMessage DeleteUser(int id)
    {
      SuccessResponse response = new SuccessResponse();
      UsersService.DeleteUser(id);
      return Request.CreateResponse(response);
    }
  }
}
