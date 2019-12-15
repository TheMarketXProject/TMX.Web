using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TMX.Web.Controllers
{
  [AllowAnonymous]
  public class PublicController : Controller
  {
    // GET: Public
    [Route("~/Login")]
    public ActionResult Login()
    {
      return View();
    }

    [Route("~/Register")]
    public ActionResult Register()
    {
      return View();
    }
  }
}