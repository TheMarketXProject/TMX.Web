using System;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMX.Web.Exceptions
{
  public class IdentityResultException : Exception
  {
    public IdentityResultException(IdentityResult result)
    {
      Result = result;
    }

    public IdentityResult Result { get; set; }
  }
}