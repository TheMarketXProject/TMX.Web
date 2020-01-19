using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMX.Data.Utlilties.SQL;

namespace TMXClasses
{
  public class UserTokens : BaseClass
  {
    #region Properties
    public Guid TokenId { get; set; }
    public string UserName { get; set; }
    public int TokenType { get; set; }
    #endregion

    #region Constructors
    public UserTokens()
    {
    }

    public UserTokens(Guid Id)
    {
      TokenId = Id;
      Load();
    }
    #endregion

    #region Public Methods
    public void Load()
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      parameters.Add(new SqlParameter("@TokenId", TokenId));
      using (SqlDataReader reader = ExecutionHelper.ExecuteReader("dbo.UserTokens_SelectByToken", parameters))
      {
        if (reader == null)
          return;
        if (reader.Read())
          SetProperties(reader);
      }
    }

    public void Add()
    {
      ArrayList propertiesToOmit = new ArrayList();
      propertiesToOmit.Add("TokenId");
      using (SqlDataReader reader = ExecutionHelper.ExecuteReader("dbo.UserTokens_Insert", GetSQLParameters(propertiesToOmit)))
      {
        if (reader == null)
          return;
        if (reader.Read())
          SetProperties(reader);
      }
    }

    public static void Delete(Guid tokenId)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      parameters.Add(new SqlParameter("@TokenId", tokenId));
      ExecutionHelper.ExecuteNonQuery("UserTokens_Delete", parameters);
    }
    #endregion

  }
}
