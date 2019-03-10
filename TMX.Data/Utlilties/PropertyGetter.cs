using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TMX.Data.Utlilties
{
  public class PropertyGetter
  {
    public static object GetPropertyValue(object Obj, string PropertyName)
    {
      object Result = null;
      System.Reflection.PropertyInfo pi;
      string[] propertyNameSplitByPeriod = PropertyName.Split('.');
      pi = Obj.GetType().GetProperty(propertyNameSplitByPeriod[0], BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
      if (pi != null)
      {
        if (propertyNameSplitByPeriod.Length > 1)
          Result = GetPropertyValue(pi.GetValue(Obj, null), PropertyName.Replace(propertyNameSplitByPeriod[0] + ".", ""));
        else
          Result = GetPropertyValue(Obj, pi);
      }
      return Result;
    }

    public static object GetPropertyValue(object Obj, System.Reflection.PropertyInfo pi)
    {
      object Result;
      if (pi.PropertyType.IsEnum)
        Result = (int)pi.GetValue(Obj, null);
      else
      {
        switch (pi.PropertyType.Name.ToLower())
        {
          case "int":
            Result = pi.GetValue(Obj, null);
            break;
          case "int32":
            Result = pi.GetValue(Obj, null);
            break;
          case "datetime":
            Result = pi.GetValue(Obj, null);
            if (IsDateNothing((DateTime)Result))
            {
              Result = DatabaseDateTimeMinValue();
            }
            else
            {
              Result = ((DateTime)Result);
            }
            break;
          case "decimal":
            Result = pi.GetValue(Obj, null);
            break;
          case "double":
            Result = pi.GetValue(Obj, null);
            break;
          case "bool":
            Result = pi.GetValue(Obj, null);
            break;
          case "boolean":
            Result = pi.GetValue(Obj, null);
            break;
          case "string":
            Result = pi.GetValue(Obj, null);
            break;
          default:
            Result = pi.GetValue(Obj, null);
            break;
        }
      }
      return Result;
    }

    public static List<SqlParameter> GetSQLParameters(object obj)
    {
      return GetSQLParameters(obj, new ArrayList());
    }

    public static List<SqlParameter> GetSQLParameters(object obj, ArrayList propertiesToOmit)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      PropertyInfo[] pis = obj.GetType().GetProperties();

      foreach (PropertyInfo pi in pis)
      {
        if (pi.CanRead && pi.CanWrite && !propertiesToOmit.Contains(pi.Name))
        {
          SqlParameter parameter = new SqlParameter();
          parameter.ParameterName = "@" + pi.Name;
          if (pi.PropertyType.IsEnum)
            parameter.SqlDbType = SqlDbType.SmallInt;
          else
          {
            switch (pi.PropertyType.Name.ToLower())
            {
              case "int":
                parameter.SqlDbType = SqlDbType.Int;
                break;
              case "int32":
                parameter.SqlDbType = SqlDbType.Int;
                break;
              case "datetime":
                if (IsDateNothing(DateTime.Parse(pi.GetValue(obj, null).ToString())))
                  parameter = null;
                else
                  parameter.SqlDbType = SqlDbType.DateTime;
                break;
              case "decimal":
                parameter.SqlDbType = SqlDbType.Decimal;
                break;
              case "double":
                parameter.SqlDbType = SqlDbType.Float;
                break;
              case "single":
                parameter.SqlDbType = SqlDbType.Decimal;
                break;
              case "bool":
                parameter.SqlDbType = SqlDbType.Bit;
                break;
              case "boolean":
                parameter.SqlDbType = SqlDbType.Bit;
                break;
              case "string":
                parameter.SqlDbType = SqlDbType.NVarChar;
                break;
              default:
                parameter = null;
                break;
            }
          }
          if (parameter != null)
          {
            parameter.Value = GetPropertyValue(obj, pi);
            parameters.Add(parameter);
          }
        }
      }
      return parameters;
    }

    public static bool IsDateNothing(DateTime DT)
    {
      if (DT == null || DT.ToShortDateString() == DateTime.MinValue.ToShortDateString() || DT <= DateTime.Parse("1/2/1753") || DT <= DateTime.Parse("1/2/1900"))
        return true;
      else
        return false;
    }

    public static DateTime DatabaseDateTimeMinValue()
    {
      return DateTime.Parse("1/1/1753");
    }
  }
}
