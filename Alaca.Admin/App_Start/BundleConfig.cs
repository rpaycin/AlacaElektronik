using System.Web.Optimization;
using WebHelpers.Mvc5;

namespace Alaca.Admin.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Bundles/css")
                .Include("~/Content/css/bootstrap.min.css", new CssRewriteUrlTransformAbsolute())
                .Include("~/Content/css/bootstrap-select.css")
                .Include("~/Content/css/bootstrap-datepicker3.min.css")
                .Include("~/Content/css/font-awesome.min.css", new CssRewriteUrlTransformAbsolute())
                .Include("~/Content/css/icheck/blue.min.css", new CssRewriteUrlTransformAbsolute())
                .Include("~/Content/css/AdminLTE.css", new CssRewriteUrlTransformAbsolute())
                .Include("~/Content/css/skins/skin-blue.css")
                .Include("~/Content/css/datatables/dataTables.bootstrap4.min.css")
                .Include("~/Content/css/datatables/responsive.bootstrap4.min.css")
                .Include("~/Content/css/datatables/buttons.bootstrap4.min.css")
                .Include("~/Content/css/editor.css"));

            bundles.Add(new ScriptBundle("~/Bundles/js")
                .Include("~/Content/js/plugins/jquery/jquery-1.12.4.js")
                .Include("~/Content/js/plugins/bootstrap/bootstrap.js")
                .Include("~/Content/js/plugins/fastclick/fastclick.js")
                .Include("~/Content/js/plugins/slimscroll/jquery.slimscroll.js")
                .Include("~/Content/js/plugins/bootstrap-select/bootstrap-select.js")
                .Include("~/Content/js/plugins/moment/moment.js")
                .Include("~/Content/js/plugins/datepicker/bootstrap-datepicker.js")
                .Include("~/Content/js/plugins/icheck/icheck.js")
                .Include("~/Content/js/plugins/validator/validator.js")
                .Include("~/Content/js/plugins/inputmask/jquery.inputmask.bundle.js")
                .Include("~/Content/js/adminlte.js")
                .Include("~/Content/js/init.js")
                .Include("~/Content/js/plugins/datatables/datatable.js")
                .Include("~/Content/js/plugins/datatables/dataTables.responsive.min.js")
                .Include("~/Content/js/plugins/datatables/dataTables.bootstrap4.min.js")
                .Include("~/Content/js/plugins/datatables/responsive.bootstrap4.min.js")
                .Include("~/Content/js/plugins/datatables/dataTables.buttons.min.js")
                .Include("~/Content/js/plugins/datatables/buttons.bootstrap4.min.js")
                .Include("~/Content/js/plugins/datatables/jszip.min.js")
                .Include("~/Content/js/plugins/datatables/buttons.html5.min.js")
                .Include("~/Content/js/plugins/datatables/buttons.print.min.js")
                .Include("~/Content/js/plugins/datatables/buttons.colVis.min.js")
                .Include("~/Content/js/editor.js"));

#if DEBUG
            BundleTable.EnableOptimizations = false;
#else
            BundleTable.EnableOptimizations = true;
#endif
        }
    }
}
