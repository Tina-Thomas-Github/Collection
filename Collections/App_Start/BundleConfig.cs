using System.Web;
using System.Web.Optimization;

namespace Collections
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/Scripts").Include(
                        "~/Scripts/jquery.dataTables.min.js", "~/Scripts/dataTables.bootstrap.min.js", "~/Scripts/jszip.min.js", "~/Content/vendor/datatables/dataTables.bootstrap4.js"
                      , "~/Scripts/vfs_fonts.js", "~/Scripts/dataTables.buttons.min.js", "~/Scripts/buttons.html5.min.js", "~/Scripts/buttons.flash.min.js", "~/Scripts/buttons.print.min.js"
                      , "~/Scripts/dataTables.fixedHeader.min.js", "~/Scripts/dataTables.responsive.min.js", "~/Scripts/responsive.bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/AllStyle").IncludeDirectory("~/CSS", "dataTables.bootstrap.min.css").IncludeDirectory("~/CSS", "bootstrap.min.css").IncludeDirectory("~/CSS", "fixedHeader.bootstrap.min.css").IncludeDirectory
                    ("~/CSS", "responsive.bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/CSS/Allstyle").Include(
                      "~/CSS/dataTables.bootstrap.min.css",
                     "~/CSS/bootstrap.min.css",
                     "~/CSS/fixedHeader.bootstrap.min.css",
                     "~/CSS/responsive.bootstrap.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/AllScripts").Include(
                       "~/Content/vendor/jquery/jquery.min.js", "~/Content/vendor/bootstrap/js/bootstrap.bundle.min.js", "~/Content/vendor/jquery-easing/jquery.easing.min.js", "~/Content/js/sb-admin-2.min.js", "~/Scripts/bootbox.min.js"));

        }
    }
}
