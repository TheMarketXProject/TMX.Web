using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMX.Web.Models.Requests
{
  public class UsersInsertRequest
  {
    public string fname { get; set; }
    public string lname { get; set; }
    public string email { get; set; }
    public string displayName { get; set; }
    public string city { get; set; }
    public string state { get; set; }
    public string password { get; set; }
    public int zipcode { get; set; }
    public string admin { get; set; }
    public string bus_id { get; set; }
    public string bus_date { get; set; }
    public string loginStatus { get; set; }
    public string about_me { get; set; }
    public string signUpDate { get; set; }
    public string changeDate { get; set; }
    public string birthDate { get; set; }
    public string facebook_id { get; set; }
  }
}