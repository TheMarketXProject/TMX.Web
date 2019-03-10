using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableExtrator.Classes;
using TMX.Web.Services;
using TMXClasses;

namespace TableExtrator
{
  public class ExtractorService
  {
    public static int ExtractUsers()
    {
      int usersExtracted = 0;
      if (Users.GetAll().Count() > 0)
        SQLHelper.ExecuteQuery("truncate table Users");
      if (UserProfiles.GetAll().Count() > 0)
        SQLHelper.ExecuteQuery("truncate table UserProfiles");
      List<OldUsers> oldUsers = OldUsers.GetAll();
      foreach (OldUsers oldUser in oldUsers)
      {

        var user = new Users()
        {
          Id = oldUser.id,
          UserType = oldUser.admin == "y" ? "Admin" : "Gen",
          IsActive = true,
          Email = oldUser.email,
          Password = oldUser.password,
          SignUpDate = DateTime.Parse(oldUser.signUpDate),
          LastLoginDate = (oldUser.loginStatus == null || oldUser.loginStatus == "0000-00-00 00:00:00") ? DateTime.MinValue : DateTime.Parse(oldUser.loginStatus)
        };

        var userId = UsersService.CreateUpdateUser(user);

        var userProfile = new UserProfiles()
        {
          UserId = userId,
          FirstName = oldUser.fname,
          LastName = oldUser.lname,
          DisplayName = oldUser.displayName,
          City = oldUser.city,
          State = oldUser.state,
          Zipcode = oldUser.zipcode,
          About = oldUser.about_me,
          BirthDate = (oldUser.birthDate == null || oldUser.birthDate == "0000-00-00") ? DateTime.MinValue : DateTime.Parse(oldUser.birthDate),
          DateCreated = DateTime.Now
        };

        UserProfilesService.CreateUpdateProfile(userProfile);

        usersExtracted++;
      }
      return usersExtracted;
    }
  }
}
