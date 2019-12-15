using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMXClasses.Users
{
  public class BusinessUser : BaseUser
  {
    #region Properties
    public string Name { get; set; }
    public string Website { get; set; }
    #endregion

    #region Constructors
    public BusinessUser()
    {
    }

    public BusinessUser(int Id)
    {
      this.Id = Id;
      //Load();
    }
    #endregion
  }
}
