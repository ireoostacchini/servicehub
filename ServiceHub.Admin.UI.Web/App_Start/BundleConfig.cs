using ServiceHub.Admin.UI.Web.Helpers;
using System.Web;
using System.Web.Optimization;

namespace ServiceHub.Admin.UI.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {

            // Force optimization to be on or off, regardless of web.config setting
           // BundleTable.EnableOptimizations = true;
            bundles.UseCdn = true;

            // .debug.js, -vsdoc.js and .intellisense.js files are in BundleTable.Bundles.IgnoreList by default.
            // Clear out the list and add back the ones we want to ignore. Don't add back .debug.js.
            bundles.IgnoreList.Clear();
            bundles.IgnoreList.Ignore("*-vsdoc.js");
            bundles.IgnoreList.Ignore("*intellisense.js");

            
            //******************************************************************JS
            #region javascript
     

            // Modernizr goes separately since it loads first
            bundles.Add(new ScriptBundle("~/bundles/modernizr")
                .Include("~/Scripts/lib/modernizr-{version}-respond-{version}.min.js"));

            // jQuery
            bundles.Add(new ScriptBundle("~/bundles/jquery", "//ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js")
                .Include("~/Scripts/lib/jquery-{version}.js"));


            // 3rd Party JavaScript files
            bundles.Add(new ScriptBundle("~/bundles/jsextlibs")
                //.IncludeDirectory("~/Scripts/lib", "*.js", searchSubdirectories: false));
                .Include(
                    "~/Scripts/lib/json2.js", // IE7 needs this

                    // jQuery plugins
                     "~/Scripts/lib/jquery-ui-{version}.js",
                    "~/Scripts/lib/activity-indicator.js",
                    "~/Scripts/lib/jquery.mockjson.js",
                    "~/Scripts/lib/TrafficCop.js",
                    "~/Scripts/lib/infuser.js", // depends on TrafficCop

                    //jQuery validation - not sure we'll keep this
                    "~/Scripts/jquery.unobtrusive*",
                    "~/Scripts/jquery.validate*",


                    // Knockout and its plugins
                    "~/Scripts/lib/knockout-{version}.js",
                    "~/Scripts/lib/knockout.activity.js",
                    "~/Scripts/lib/knockout.command.js",
                    "~/Scripts/lib/knockout.dirtyFlag.js",
                    "~/Scripts/lib/knockout.validation.js",
                    "~/Scripts/lib/koExternalTemplateEngine.js",    //after knockout and jquery

                    // Other 3rd party libraries
                    "~/Scripts/lib/underscore.js",
                    "~/Scripts/lib/moment.js",
                    "~/Scripts/lib/sammy-{version}.js",
                    "~/Scripts/lib/amplify.*",
                    "~/Scripts/lib/amplify.request.deferred.*", //must be after amplify
                    "~/Scripts/lib/toastr.js",
                    "~/Scripts/lib/sugar.min.js"
                    ));


            //js mocks
            bundles.Add(new ScriptBundle("~/bundles/jsmocks")
                   .IncludeDirectory("~/Scripts/app/mock", "*.js", searchSubdirectories: false));

            // All application JS files (except mocks)
            bundles.Add(new ScriptBundle("~/bundles/jsapplibs")
                .IncludeDirectory("~/Scripts/app/", "*.js", searchSubdirectories: false));

            #endregion

            #region CSS

            //******************************************************************CSS


            //Content - except jQueryUI themes
            bundles.Add(new StyleBundle("~/Content/css/ext")
                .Include(
                "~/Content/css/bootstrap.min.css",
                "~/Content/css/bootstrap-responsive.min.css",
                "~/Content/css/toastr.css"
                ));


            //Content - jQueryUI
            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css"

                        //add others as required
                        ));


            // Custom LESS files
            bundles.Add(new Bundle("~/Content/css/less", new LessTransform(), new CssMinify())
                .Include("~/Content/css/site.less"));
        }


            #endregion

    }
}