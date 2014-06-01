using System;
using System.Web.Optimization;

[assembly: WebActivator.PostApplicationStartMethod(
    typeof(ServiceHub.Admin.UI.WebD.App_Start.DurandalConfig), "PreStart")]

namespace ServiceHub.Admin.UI.WebD.App_Start
{
    public static class DurandalConfig
    {
        public static void PreStart()
        {
            // Add your start logic here
            DurandalBundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}