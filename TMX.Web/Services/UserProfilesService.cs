using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMXClasses;

namespace TMX.Web.Services
{
  public class UserProfilesService
  {
    public static List<UserProfiles> GetAllUserProfiles()
    {
      return UserProfiles.GetAll();
    }

    public static UserProfiles GetUser(int id)
    {
      return UserProfiles.GetUser(id);
    }

    public static int CreateUpdateProfile(object model)
    {
      UserProfiles user = new UserProfiles();
      user.Clone(model);
      user.Update();
      return user.Id;
    }

    public static void DeleteUser(int id)
    {
      UserProfiles.Delete(id);
    }
  }
}