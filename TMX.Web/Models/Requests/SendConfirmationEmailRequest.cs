using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TMX.Web.Models.Requests
{
  public class SendConfirmationEmailRequest
  {
    [Required]
    public string Username { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public Guid Token { get; set; }

    public SendConfirmationEmailRequest() { }

    public SendConfirmationEmailRequest(string username, string email, Guid token)
    {
      Username = username;
      Email = email;
      Token = token;
    }
  }
}