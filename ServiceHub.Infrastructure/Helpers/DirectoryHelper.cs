using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceHub.Infrastructure.Helpers
{
    internal class DirectoryHelper
    {
       static string _bin = @"\bin\";

       internal static string GetApplicationDirectory()
        {

            //if it's web app, just return the BaseDirectory
            if (!IsWindowsApplication) return AppDomain.CurrentDomain.BaseDirectory;


            //otherwise, it must be a windows app. Crop to the \ just before the bin
            var appDirPath = AppDomain.CurrentDomain.BaseDirectory;

            var position = appDirPath.IndexOf(_bin) + 1;  //+1 means we keep the ending \

            appDirPath = appDirPath.Substring(0, position);

            return appDirPath;
        }


       internal static string GetBinDirectory()
        {

            //if it's a windows app, do this:
            if (IsWindowsApplication) return AppDomain.CurrentDomain.BaseDirectory;


            //otherwise, it must be a web app - do this:
            return AppDomain.CurrentDomain.SetupInformation.ShadowCopyDirectories + "\\";

        }

        /// <summary>
        /// if true, we're in an ASP.NET application. Otherwise, it's a windows app
        /// when we get round to working with other types of app, we'll extend this
        /// </summary>
        internal static bool IsWindowsApplication
        {
            get
            {
                var appDirPath = AppDomain.CurrentDomain.BaseDirectory;

                //if the BaseDirectory contains bin, that means it's a windows app. 
                //if it doesn't contain bin, it's a web app - as BaseDirectory refers to the project folder

                return (appDirPath.ToLower().Contains(_bin));
            }
        }
    }
}
