using System.Web;
using System.Web.Optimization;

namespace ICOnboardingP3
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/moment.min.js",
                "~/Scripts/knockout-3.4.2.js",
                "~/Scripts/knockout.mapping-lastest.js",
                "~/Scripts/knockout.validation.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/Site.css",
                        "~/Content/bootstrap.css",
                        "~/Content/font-awesome.css"
                      ));
        }
    }
}
