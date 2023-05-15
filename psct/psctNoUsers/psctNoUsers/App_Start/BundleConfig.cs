using System.Web.Optimization;

namespace psct
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                                                                        "~/Scripts/jquery.validate*"));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                                                                 "~/Content/bootstrap.min.css"
                                                               , "~/Content/site/main.css"));

            bundles.Add(new Bundle("~/bundles/js").Include(
                                                           "~/Scripts/modernizr-*"
                                                         , "~/Scripts/jquery-{version}.min.js"
                                                         , "~/Scripts/bootstrap.bundle.min.js"
                                                         , "~/Scripts/site/jquery.min.js"
                                                         , "~/Scripts/site/jquery.scrolly.min.js"
                                                         , "~/Scripts/site/jquery.scrollex.min.js"
                                                         , "~/Scripts/site/browser.min.js"
                                                         , "~/Scripts/site/breakpoints.min.js"
                                                         , "~/Scripts/site/util.js"
                                                         , "~/Scripts/site/main.js"
                                                          ));

            // Code removed for clarity.
            BundleTable.EnableOptimizations = true;
        }
    }
}
