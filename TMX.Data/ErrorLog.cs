using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMX.Data.Utlilties.SQL;

namespace TMX.Data
{
  public class ErrorLog
  {
    #region Members
    private Exception _Ex = new Exception();
    private string _URL = "";
    private int _UserID = 0;
    private string _ErrorMsg = "";
    #endregion

    #region Properties
    public System.Exception Ex
    {
      get
      {
        return _Ex;
      }
      set
      {
        _Ex = value;
      }
    }

    public string URL
    {
      get
      {
        return _URL;
      }
      set
      {
        _URL = value;
      }
    }

    public int UserID
    {
      get
      {
        return _UserID;
      }
      set
      {
        _UserID = value;
      }
    }

    public string ErrorMsg
    {
      get
      {
        return _ErrorMsg;
      }
      set
      {
        _ErrorMsg = value;
      }
    }
    #endregion

    #region Public Methods
    public ErrorLog()
    {

    }

    public ErrorLog(Exception e)
    {
      _Ex = e;
    }

    public void LogError()
    {
      //SendErrorEmail();
      //LogErrorInDatabase();
    }

    //public void SendErrorEmail()
    //{
    //  try
    //  {
    //    MailMessage mm = new MailMessage();
    //    mm.To.Add(new MailAddress(GetSquawksEmailAddress()));
    //    mm.From = new MailAddress("donotreply@fuelerlinx.com");
    //    mm.Subject = "An unhandled exception occurred on DegaFuelManagement";
    //    mm.Body = "URL: " + _URL + Environment.NewLine;
    //    mm.Body += "UserID: " + _UserID.ToString() + Environment.NewLine + Environment.NewLine;
    //    mm.Body += "Exception Details:" + Environment.NewLine;
    //    if (_ErrorMsg.Length > 0)
    //      mm.Body += _ErrorMsg;
    //    else
    //      mm.Body += _Ex.Message + "***" + _Ex.InnerException + "****" + _Ex.StackTrace;
    //    Data.Utilities.SendEmail(mm);
    //  }
    //  catch (System.Exception exc)
    //  {

    //  }
    //}

    //public void LogErrorInDatabase()
    //{
    //  List<SqlParameter> Params = new List<SqlParameter>();
    //  SqlParameter Param = new SqlParameter("@Err_DateTime", SqlDbType.DateTime);
    //  Param.Value = DateTime.Now;
    //  Params.Add(Param);
    //  Param = new SqlParameter("@Err_Message", SqlDbType.VarChar);
    //  if (_Ex != null)
    //    Param.Value = _Ex.Message;
    //  else
    //    Param.Value = "";
    //  Params.Add(Param);
    //  try
    //  {
    //    Param = new SqlParameter("@Err_URL", SqlDbType.VarChar, 500);
    //    if (String.IsNullOrEmpty(_URL))
    //      _URL = HttpContext.Current.Request.Url.ToString();
    //    Param.Value = _URL;
    //    Params.Add(Param);
    //    Param = new SqlParameter("@UserID", SqlDbType.Int);
    //    Param.Value = _UserID;
    //    Params.Add(Param);
    //    Param = new SqlParameter("@Err_Exception", SqlDbType.VarChar);
    //    if (_ErrorMsg.Length > 0)
    //      Param.Value = _ErrorMsg;
    //    else
    //    {
    //      if (_Ex.InnerException != null)
    //        Param.Value = _Ex.Message + "***" + _Ex.InnerException.StackTrace + "****" + _Ex.StackTrace;
    //      else
    //        Param.Value = _Ex.Message + "****" + _Ex.StackTrace;
    //    }
    //    Params.Add(Param);
    //    ExecutionHelper.ExecuteWithoutLogging("up_LogError", Params, ExecutionHelper.GetConnectionString());
    //  }
    //  catch (System.Exception ex)
    //  {
    //  }
    //}
    #endregion

    #region Private Methods
    //private string GetSquawksEmailAddress()
    //{
    //  string mailAddress = ConfigurationManager.AppSettings["MailSquawksAddress"];
    //  if (string.IsNullOrEmpty(mailAddress))
    //    return "squawks@fuelerlinx.com";
    //  return mailAddress;
    //}
    #endregion

    #region Static Methods
    public static void LogAndEmailError(System.Exception exception, string methodDetails, int userID)
    {
      ErrorLog errorLog = new ErrorLog(exception);
      errorLog.UserID = userID;
      errorLog.URL = methodDetails;
      errorLog.LogError();
    }
    #endregion
  }
}
