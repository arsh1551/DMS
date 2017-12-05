using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntites.Common.Helper
{
    public static class WebConfigurationHelper
    {
        /// <summary>
        /// method for getting the connection string
        /// </summary>
        /// <param name="connectionStringName"></param>
        /// <returns></returns>
        public static string GetConnectionString(string connectionStringName)
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings[connectionStringName]
                .ConnectionString;
        }
        public static string GetAppSettingValue(string key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[key];
        }
    }
}
