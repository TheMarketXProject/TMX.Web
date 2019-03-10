﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TMX.Data.Extensions;
using System.Data.SqlClient;
using TMX.Web.Models.Requests;
using TMXClasses;

namespace TMX.Web.Services
{
  public class UsersService : BaseService
  {
    public static List<Users> GetAllUsers()
    {
      return Users.GetAll();
    }

    public static Users GetUser(int id)
    {
      return Users.GetUser(id);
    }

    public static int CreateUpdateUser(object model)
    {
      Users user = new Users();
      user.Clone(model);
      user.Update();
      return user.Id;
    }

    public static void DeleteUser(int id)
    {
      Users.Delete(id);
    }

    //private static void GetValues(SqlParameterCollection collection, dynamic model)
    //{
    //  if (model is UsersUpdateRequest)
    //  {
    //    collection.AddWithValue("@Id", model.id);
    //  }
    //  collection.AddWithValue("@fname", model.fname);
    //  collection.AddWithValue("@lname", model.lname);
    //  collection.AddWithValue("@email", model.email);
    //  collection.AddWithValue("@displayName", model.displayName);
    //  collection.AddWithValue("@city", model.city);
    //  collection.AddWithValue("@state", model.state);
    //  collection.AddWithValue("@password", model.password);
    //  collection.AddWithValue("@zipcode", model.zipcode);
    //  collection.AddWithValue("@admin", model.admin);
    //  collection.AddWithValue("@bus_id", model.bus_id);
    //  collection.AddWithValue("@bus_date", model.bus_date);
    //  collection.AddWithValue("@loginStatus", model.loginStatus);
    //  collection.AddWithValue("@about_me", model.about_me);
    //  collection.AddWithValue("@signUpDate", model.signUpDate);
    //  collection.AddWithValue("@changeDate", model.changeDate);
    //  collection.AddWithValue("@birthDate", model.birthDate);
    //  collection.AddWithValue("@facebook_id", model.facebook_id);
    //}

    //private static Users MapUsers(IDataReader reader)
    //{
    //  Users item = new Users();
    //  int startingIndex = 0;

    //  item.id = reader.GetSafeInt32(startingIndex++);
    //  item.fname = reader.GetSafeString(startingIndex++);
    //  item.lname = reader.GetSafeString(startingIndex++);
    //  item.email = reader.GetSafeString(startingIndex++);
    //  item.displayName = reader.GetSafeString(startingIndex++);
    //  item.city = reader.GetSafeString(startingIndex++);
    //  item.state = reader.GetSafeString(startingIndex++);
    //  item.password = reader.GetSafeString(startingIndex++);
    //  item.zipcode = reader.GetSafeInt32(startingIndex++);
    //  item.admin = reader.GetSafeString(startingIndex++);
    //  item.bus_id = reader.GetSafeString(startingIndex++);
    //  item.bus_date = reader.GetSafeString(startingIndex++);
    //  item.loginStatus = reader.GetSafeString(startingIndex++);
    //  item.about_me = reader.GetSafeString(startingIndex++);
    //  item.signUpDate = reader.GetSafeString(startingIndex++);
    //  item.changeDate = reader.GetSafeString(startingIndex++);
    //  item.birthDate = reader.GetSafeString(startingIndex++);
    //  item.facebook_id = reader.GetSafeString(startingIndex++);

    //  return item;
    //}
  }
}