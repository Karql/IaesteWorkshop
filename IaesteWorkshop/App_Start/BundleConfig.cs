using System.Web;
using System.Web.Optimization;

namespace IaesteWorkshop
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.magnific-popup.js",
                        "~/Scripts/jquery.flexisel.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/popuo-box.css",
                      "~/Content/style.css"));

            bundles.Add(new ScriptBundle("~/bundles/angularjs").Include(
                      "~/Scripts/angular.js*"));


            bundles.Add(new ScriptBundle("~/bundles/movieComments").Include(
                    "~/Scripts/app/movie-comments/movie-comments.service.js",
                    "~/Scripts/app/movie-comments/movie-comments.controller.js",
                    "~/Scripts/app/movie-comments/movie-comments.module.js"
                    ));
        }
    }
}
