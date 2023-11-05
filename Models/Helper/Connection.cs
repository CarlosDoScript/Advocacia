﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Advocacia.Models.Helper
{
    public class Connection
    {
        public SqlConnection SQL()
        {
            try
            {
                var connectionString =  new SqlConnection(WebConfigurationManager.AppSettings["AdvocaciaConnection"]);
                return connectionString;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}