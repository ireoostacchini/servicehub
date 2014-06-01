using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceHub.Test.System
{
    public static class Config
    {

        public static string SiteUrlTest
        {
            get
            {
                return ConfigurationManager.AppSettings["SiteUrlTest"];
            }
        }
        public static string SiteUrlStaging
        {
            get
            {
                return ConfigurationManager.AppSettings["SiteUrlStaging"];
            }
        }
        public static string SiteUrlProduction
        {
            get
            {
                return ConfigurationManager.AppSettings["SiteUrlProduction"];
            }
        }
    }
}
