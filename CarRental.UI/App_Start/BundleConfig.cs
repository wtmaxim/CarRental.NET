using System.Web;
using System.Web.Optimization;

namespace CarRental.UI
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilisez la version de développement de Modernizr pour le développement et l'apprentissage. Puis, une fois
            // prêt pour la production, utilisez l'outil de génération à l'adresse https://modernizr.com pour sélectionner uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/adminlte.min.js",
                      "~/Scripts/demo.js",
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/moment/moment.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/font-awesome/css/font-awesome.css",
                      "~/Content/Ionicons/css/ionicons.css",
                      "~/Content/AdminLTE.min.css",
                      "~/Content/skins/_all-skins.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/fullcalendar").Include(
                "~/Scripts/fullcalendar/core/main.js",
                "~/Scripts/fullcalendar/daygrid/main.js",
                "~/Scripts/fullcalendar/core/locale/fr.js"));

            bundles.Add(new StyleBundle("~/Content/fullcalendar").Include(
                "~/Content/fullcalendar/core/main.css",
                "~/Content/fullcalendar/daygrid/main.css"));

            bundles.Add(new ScriptBundle("~/bundles/select2").Include(
                "~/Scripts/Select2/select2.full.min.js"));

            bundles.Add(new StyleBundle("~/Content/select2").Include(
                "~/Content/Select2/select2.min.css",
                "~/Content/Select2/select2-bootstrap.min.css"));

        }
    }
}
