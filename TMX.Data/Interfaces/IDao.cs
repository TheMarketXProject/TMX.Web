using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMX.Data.Interfaces
{
  public interface IDao
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="dataSouce">The Connection we use to get to the database we want</param>
    /// <param name="storedProc">The name of the procedure we want to execute</param>
    /// <param name="inputParamMapper"></param>
    /// <param name="map"></param>
    /// <param name="returnParameters"></param>
    /// <param name="cmdModifier"></param>
    void ExecuteCmd(
      Func<SqlConnection> dataSouce,
      string storedProc,
      Action<SqlParameterCollection> inputParamMapper,
       Action<IDataReader, short> map,

      Action<SqlParameterCollection> returnParameters = null,
      Action<SqlCommand> cmdModifier = null);


    int ExecuteNonQuery(Func<SqlConnection> dataSouce, string storedProc,
      Action<SqlParameterCollection> inputParamMapper,
      Action<SqlParameterCollection> returnParameters = null);
  }
}
