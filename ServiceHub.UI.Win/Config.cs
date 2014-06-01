// -----------------------------------------------------------------------
// <copyright file="Config.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System.Configuration;


namespace ServiceHub.UI.Win
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Configuration;
    using ServiceHub.UI.Interfaces;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public  class Config:IConfig
    {


        /// <summary>
        ///  the no.of seconds between service monitoring episodes
        /// </summary>
        public int MonitorInterval
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["MonitorInterval"]);
            }
        }

        public string DataServiceBaseUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["DataServiceBaseUrl"];
            }
        }

    }
}
