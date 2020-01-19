using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMX.Web.Models.ViewModels;

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

    [Route("~/Confirm/{token:guid}")]
    public ActionResult ConfirmEmail(Guid token)
    {
      ItemViewModel<Guid> model = new ItemViewModel<Guid>();
      model.Item = token;
      return View(model);
    }
  }
}