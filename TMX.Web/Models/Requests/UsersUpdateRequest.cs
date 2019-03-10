using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TMX.Web.Models.Requests
{
  public class UsersUpdateRequest : UsersInsertRequest
  {
    [Required]
    public int id { get; set; }
  }
}