using System.Web.Optimization;

namespace Home
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/assets/js/jQuery").Include(
                    "~/assets/js/jquery.min.js"
                ));

            bundles.Add(new ScriptBundle("~/assets/js/externos").Include(
                    "~/assets/js/bootstrap.min.js",
                    "~/assets/js/bootstrap-hover-dropdown.min.js",
                    "~/assets/js/jquery-migrate.min.js",
                    "~/assets/js/jquery-ui.min.js",
                    "~/assets/js/jquery.slimscroll.min.js",
                    "~/assets/js/jquery.blockUI.min.js",
                    "~/assets/js/jquery.cookie.min.js",
                    "~/assets/js/jquery.uniform.standalone.js",
                    "~/assets/js/bootstrap-switch.min.js",
                    "~/assets/js/bootstrap-fileinput.js",
                    "~/assets/js/jquery.sparkline.min.js",
                    "~/assets/js/jquery.validate.min.js",
                    "~/assets/js/jquery.validate.unobtrusive.min.js",
                    "~/assets/js/jquery.toast.js"
                ));

            bundles.Add(new ScriptBundle("~/assets/js").Include(
                    "~/assets/js/metronic.js",
                    "~/assets/js/layout.js",
                    "~/assets/js/login.js",
                    "~/assets/js/profile.js",
                    "~/assets/js/quick-sidebar.js",
                    "~/assets/js/timeline.js",
                    "~/assets/js/demo.js",
                    "~/assets/js/common.js"
                ));

            bundles.Add(new ScriptBundle("~/assets/js/SignalR").Include(
                       "~/assets/js/jquery.signalR-{version}.js"));

            bundles.Add(new StyleBundle("~/assets/css").Include(
                    "~/assets/css/blog.css",
                    "~/assets/css/components-md.css",
                    "~/assets/css/custom.css",
                    "~/assets/css/darkblue.css",
                    "~/assets/css/layout.css",
                    "~/assets/css/login.css",
                    "~/assets/css/plugins-md.css",
                    "~/assets/css/profile.css",
                    "~/assets/css/tasks.css",
                    "~/assets/css/timeline.css"
                ));

            bundles.Add(new StyleBundle("~/assets/css/externos").Include(
                    "~/assets/css/bootstrap-fileinput.css",
                    "~/assets/css/bootstrap.min.css",
                    "~/assets/css/uniform.css",
                    "~/assets/css/bootstrap-switch.min.css",
                    "~/assets/css/jquery.toast.css"
                ));

            BundleTable.EnableOptimizations = false;
        }
    }
}
