using System.Web;
using System.Web.Optimization;

namespace PC.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            // jquery mobile
            bundles.Add(new StyleBundle("~/bundles/jquery.mobile/css").Include(
                "~/Content/jquery.mobile-{version}.css"
                , "~/Content/jquery.mobile.theme-{version}.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jquery.mobile").Include(
                        "~/Scripts/jquery.mobile-*"
                        , "~/Scripts/jquery.signalR-{version}.js"
                        , "~/Scripts/jquery-{version}.js"
                        ));

            // knockout
            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                    "~/Scripts/knockout-{version}.js"
                    ,"~/Scripts/app/ko.bindingHandlers.slider.js"
                    ));

        }
    }
}