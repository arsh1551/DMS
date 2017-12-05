using System.Web;
using System.Web.Optimization;

namespace DMS
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
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/moment.js",
                      "~/Scripts/bootstrap-datepicker.js",
                      "~/Scripts/custom.js",
                      "~/Scripts/bootstrap-select.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/JQGridScripts").Include(
                    "~/Scripts/jquery-ui-1.12.1.min.js",
                    "~/Scripts/i18n/grid.locale-en.js",
                    "~/Scripts/jquery.jqGrid.js"
                    ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/simple-sidebar.css",
                      "~/Content/common.css",
                       "~/Content/hover.css",
                      "~/Content/style.css",
                       "~/Content/responsive.css",
                       "~/Content/font-awesome.min.css",
                       "~/Content/Developer.css",
                      "~/Content/bootstrap-datepicker.css",
                      "~/Content/simple-sidebar.css",
                      "~/Content/jquery.jqGrid/ui.jqgrid.css",
                      "~/Content/jquery.jqGrid/jqGrid.bootstrap.css"
                      ));
            //"~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/jQuery-File-Upload").Include(
                 "~/Content/jQuery.FileUpload/css/jquery.fileupload.css",
                "~/Content/jQuery.FileUpload/css/jquery.fileupload-ui.css",
                 "~/Content/blueimp-gallery2/css/blueimp-gallery.css",
                     "~/Content/blueimp-gallery2/css/blueimp-gallery-video.css",
                       "~/Content/blueimp-gallery2/css/blueimp-gallery-indicator.css"
           ));
            bundles.Add(new ScriptBundle("~/bundles/jQuery-File-Upload").Include(
                        "~/Scripts/jQuery.FileUpload/vendor/jquery.ui.widget.js",
                        "~/Scripts/jQuery.FileUpload/tmpl.min.js",
                        "~/Scripts/jQuery.FileUpload/load-image.all.min.js",
                        "~/Scripts/jQuery.FileUpload/jquery.iframe-transport.js",
                        "~/Scripts/jQuery.FileUpload/jquery.fileupload.js",
                        "~/Scripts/jQuery.FileUpload/jquery.fileupload-process.js",
                        "~/Scripts/jQuery.FileUpload/jquery.fileupload-image.js",
                        "~/Scripts/jQuery.FileUpload/jquery.fileupload-audio.js",
                        "~/Scripts/jQuery.FileUpload/jquery.fileupload-video.js",
                        "~/Scripts/jQuery.FileUpload/jquery.fileupload-validate.js",
                        "~/Scripts/jQuery.FileUpload/jquery.fileupload-ui.js",
                        //Blueimp Gallery 2 
                        "~/Scripts/blueimp-gallery2/js/blueimp-gallery.js",
                        "~/Scripts/blueimp-gallery2/js/blueimp-gallery-video.js",
                        "~/Scripts/blueimp-gallery2/js/blueimp-gallery-indicator.js",
                        "~/Scripts/blueimp-gallery2/js/jquery.blueimp-gallery.js",
                        "~/Scripts/jQuery.FileUpload/jquery.iframe-transport.js"

));
        }
        
    }
}
