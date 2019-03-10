using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMX.Data.Utlilties
{
  public class GlobalVariables
  {
    #region Static Members
    private static string _CultureInfo = "en-US";
    #endregion

    #region Static Properties
    public static string CultureInfo
    {
      get { return _CultureInfo; }
      set { _CultureInfo = value; }
    }
    #endregion
  }
}
