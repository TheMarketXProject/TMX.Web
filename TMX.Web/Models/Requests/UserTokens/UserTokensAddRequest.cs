using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TMX.Web.Models.Requests.UserTokens
{
  public class UserTokensAddRequest
  {
    public Guid TokenId { get; set; }

    [Required]
    [MaxLength(256)]
    public string UserName { get; set; }

    public int TokenType { get; set; }

    public UserTokensAddRequest()
    { }

    public UserTokensAddRequest(string username, int tokenType)
    {
      UserName = username;
      TokenType = tokenType;
    }
  }
}