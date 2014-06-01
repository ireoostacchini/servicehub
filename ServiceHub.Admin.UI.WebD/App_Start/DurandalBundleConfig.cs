using System;
using System.Web.Optimization;
using ServiceHub.Admin.UI.WebD.Helpers;

namespace ServiceHub.Admin.UI.WebD
{
    public class DurandalBundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();
            AddDefaultIgnorePatterns(bundles.IgnoreList);

            // Modernizr goes separately since it loads first
            bundles.Add(new ScriptBundle("~/bundles/modernizr")
                .Include("~/Scripts/modernizr-{version}-respond-{version}.min.js"));

            bundles.Add(
              new ScriptBundle("~/scripts/vendor")

                //core
                .Include("~/Scripts/jquery-{version}.min.js")
                .Include("~/Scripts/knockout-{version}.js")
                .Include("~/Scripts/sammy-{version}.min.js")
                .Include("~/Scripts/bootstrap.min.js")
                .Include("~/Scripts/toastr.min.js")
                .Include("~/Scripts/infuser.min.js")
                .Include("~/Scripts/underscore.min.js")
                .Include("~/Scripts/json2.min.js")
                .Include("~/Scripts/sugar.min.js")

                .Include("~/Scripts/amplify.min.js")
                .Include("~/Scripts/amplify.request.deferred.min.js")    //must be after amplify
                
                //knockout plugins
                .Include("~/Scripts/knockout.activity.js")
                .Include("~/Scripts/knockout.asyncCommand.js")
                .Include("~/Scripts/knockout.dirtyFlag.js")
                .Include("~/Scripts/knockout.validation.js")
                .Include("~/Scripts/koExternalTemplateEngine.js")    //after knockout and jquery
              );

            bundles.Add(
              new StyleBundle("~/Content/css")
                .Include("~/Content/ie10mobile.css")
                .Include("~/Content/bootstrap.min.css")
                .Include("~/Content/bootstrap-responsive.min.css")
                .Include("~/Content/durandal.css")
                .Include("~/Content/toastr.css")
              );

            // Custom LESS files
            bundles.Add(new Bundle("~/Content/css/less", new LessTransform(), new CssMinify())
                .Include("~/Content/site.less"));
        }

        public static void AddDefaultIgnorePatterns(IgnoreList ignoreList)
        {
            if (ignoreList == null)
            {
                throw new ArgumentNullException("ignoreList");
            }

            ignoreList.Ignore("*.intellisense.js");
            ignoreList.Ignore("*-vsdoc.js");
            ignoreList.Ignore("*.debug.js", OptimizationMode.WhenEnabled);
            //ignoreList.Ignore("*.min.js", OptimizationMode.WhenDisabled);
            //ignoreList.Ignore("*.min.css", OptimizationMode.WhenDisabled);
        }
    }
}