using TMX.Data.Providers;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMX.Data.Interfaces;

namespace TMX.Web.Services
{
    public abstract class BaseService
    {
        protected static IDao DataProvider
        {
            get { return TMX.Data.DataProvider.Instance; }
        }

        protected static SqlConnection GetConnection()
        {
            return new SqlConnection(System.Web.Configuration.WebConfigurationManager
                .ConnectionStrings["DefaultConnection"].ConnectionString);
        }

    }
}