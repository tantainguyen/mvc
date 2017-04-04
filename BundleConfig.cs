using System.Web;
using System.Web.Optimization;
using System.Web.Optimization.React;

namespace VST
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/lib/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/lib/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/lib/modernizr-*"));
                        
            bundles.Add(new ScriptBundle("~/bundles/react").Include(
                      "~/Scripts/lib/jquery-1.10.2.min.js",
                      "~/Scripts/lib/bootstrap.min.js",

                      "~/Scripts/react/react.min.js",
                      //"~/Scripts/react/react-with-addons.min.js",
                      "~/Scripts/react/react-dom.min.js",
                      "~/Scripts/react/react-bootstrap.js"
                      //use in <script type="text/babel"></script>
                      //"~/Scripts/react/babel-browser.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                       "~/Scripts/lib/bootstrap.js",
                       "~/Scripts/lib/respond.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/vstf.css"));
          
            bundles.Add(new BabelBundle("~/bundles/vstfjsx").Include(
                           // Add your JSX files here
                           "~/Scripts/jsx/shared/vstf.jsx"
            ));        

            //optimization all in one file
            BundleTable.EnableOptimizations = true;
        }
    }
}
