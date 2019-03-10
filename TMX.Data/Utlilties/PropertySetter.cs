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
  public class PropertySetter
  {
    #region Static Methods
    public static void SetProperties(SqlDataReader rdr, Object obj)
    {
      for (int i = 0; i < rdr.FieldCount; i++)
      {
        PropertyInfo pi = obj.GetType().GetProperty(rdr.GetName(i), BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
        SetPropertyValue(obj, pi, rdr.GetValue(i));
      }
    }

    public static void SetProperties(DataRow row, Object obj)
    {
      for (int i = 0; i < row.Table.Columns.Count; i++)
      {
        PropertyInfo pi = obj.GetType().GetProperty(row.Table.Columns[i].ColumnName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
        SetPropertyValue(obj, pi, row[i].ToString());
      }
    }

    public static void SetProperties(System.Xml.XmlNode node, Object obj)
    {
      for (int i = 0; i < node.ChildNodes.Count; i++)
      {
        PropertyInfo pi = obj.GetType().GetProperty(node.ChildNodes[i].Name, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
        if (pi == null || pi.PropertyType == typeof(string) || !XML.HasChildNodes(node.ChildNodes[i]))
          SetPropertyValue(obj, pi, node.ChildNodes[i].InnerXml);
        else
          SetProperties(node.ChildNodes[i], pi.GetValue(obj, null));
      }
    }

    public static void SetProperties(Object objectToCopy, Object obj)
    {
      Type objectToCopyType = objectToCopy.GetType();
      foreach (PropertyInfo copyPI in objectToCopyType.GetProperties())
      {
        if (copyPI.CanRead)
        {
          PropertyInfo pi = obj.GetType().GetProperty(copyPI.Name, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
          SetPropertyValue(obj, pi, copyPI.GetValue(objectToCopy, null));
        }
      }
    }

    public static void SetPropertyValue(object obj, PropertyInfo objectPropertyInfo, object value)
    {
      if (objectPropertyInfo != null && objectPropertyInfo.CanWrite && value != DBNull.Value)
      {
        try
        {
          if (objectPropertyInfo.PropertyType.IsEnum)
            objectPropertyInfo.SetValue(obj,
                                        Enum.Parse(objectPropertyInfo.PropertyType, value.ToString(), true),
                                        null);
          else if (objectPropertyInfo.PropertyType == typeof(DateTime))
            SetDatePropertyValue(obj, objectPropertyInfo, value);
          else
            objectPropertyInfo.SetValue(obj, Convert.ChangeType(value, objectPropertyInfo.PropertyType), null);
        }
        catch (Exception)
        {
          //Property could not be set.  Ignore.
        }
      }
    }

    private static void SetDatePropertyValue(object obj, PropertyInfo objectPropertyInfo, object value)
    {

      try
      {
        objectPropertyInfo.SetValue(obj,
                                    value == null
                                        ? DateTime.MinValue
                                        : DateTime.Parse(value.ToString(),
                                                         new System.Globalization.CultureInfo(
                                                             GlobalVariables.CultureInfo, false)),
                                    null);
      }
      catch
      {
        objectPropertyInfo.SetValue(obj,
                                    value == null
                                        ? DateTime.MinValue
                                        : DateTime.Parse(value.ToString()), null);
      }
    }

    public static void SetPropertyValue(object obj, string propertyName, object value)
    {
      string[] propertyNameSplit = propertyName.Split('.');
      PropertyInfo pi = obj.GetType().GetProperty(propertyNameSplit[0], BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
      if (propertyNameSplit.Length > 1)
      {
        object propertyValueAsObject = pi.GetValue(obj, null);
        SetPropertyValue(propertyValueAsObject, propertyNameSplit[1], value);
      }
      else
        SetPropertyValue(obj, pi, value);
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
            switch (pi.GetValue(obj, null).GetType().Name.ToLower())
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

    public static object GetPropertyValue(object Obj, System.Reflection.PropertyInfo pi)
    {
      object Result;
      if (pi.PropertyType.IsEnum)
        Result = (int)pi.GetValue(Obj, null);
      else
      {
        switch (pi.PropertyType.Name.ToLower())
        {
          case "datetime":
            Result = pi.GetValue(Obj, null);
            if (IsDateNothing((DateTime)Result))
              Result = DatabaseDateTimeMinValue();
            else
              Result = ((DateTime)Result);
            break;
          default:
            Result = pi.GetValue(Obj, null);
            break;
        }
      }
      return Result;
    }

    public static void Clone(Object objectToCopy, Object obj)
    {
      Type objectToCopyType = objectToCopy.GetType();
      System.Reflection.PropertyInfo pi;
      foreach (System.Reflection.PropertyInfo copyPI in objectToCopyType.GetProperties())
      {
        if (copyPI.CanRead)
        {
          pi = obj.GetType().GetProperty(copyPI.Name, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
          SetPropertyValue(obj, pi, copyPI.GetValue(objectToCopy, null));
        }
      }
    }
    #endregion

    #region Private Methods
    private static DateTime DatabaseDateTimeMinValue()
    {
      return DateTime.Parse("1/1/1753");
    }

    private static bool IsDateNothing(DateTime dateTime)
    {
      if (dateTime == null || dateTime.ToShortDateString() == DateTime.MinValue.ToShortDateString() || dateTime <= DateTime.Parse("1/2/1753") || dateTime <= DateTime.Parse("1/2/1900"))
        return true;
      return false;
    }
    #endregion
  }
}
