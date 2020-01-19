using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using TMX.Web.Models.Requests;
using TMX.Web.Models.Responses;
using TMX.Web.Services;

namespace TMX.Web.Controllers.Api
{
  [RoutePrefix("api/message")]
  public class MessageAPIController : ApiController
  {
    [Route("ConfirmEmail"), HttpPost]
    public async Task<HttpResponseMessage> SendConfirmMail(SendConfirmationEmailRequest model)
    {
      if (!ModelState.IsValid)
      {
        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
      }

      SuccessResponse response = new SuccessResponse();
      MessagingService messaging = new MessagingService();
      await messaging.SendConfirmationEmail(model);

      return Request.CreateResponse(response);
    }
  }
}
