using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Alaca.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "mikro_satis",
               url: "mikro_satis",
               defaults: new { controller = "Hizmetlerimiz", action = "Index", id = "1" }
           );

            routes.MapRoute(
             name: "proje_danismanlik",
             url: "proje_danismanlik",
             defaults: new { controller = "Hizmetlerimiz", action = "Index", id = "2" }
         );

            routes.MapRoute(
           name: "ozel_yazilim",
           url: "ozel_yazilim",
           defaults: new { controller = "Hizmetlerimiz", action = "Index", id = "3" }
       );

            routes.MapRoute(
           name: "pos_cozumleri",
           url: "pos_cozumleri",
           defaults: new { controller = "Hizmetlerimiz", action = "Index", id = "4" }
       );

            routes.MapRoute(
          name: "mikro",
          url: "mikro",
          defaults: new { controller = "Sektorler", action = "Index", id = "1" }
      );

            routes.MapRoute(
          name: "etiket",
          url: "etiket",
          defaults: new { controller = "Sektorler", action = "Index", id = "2" }
      );

            routes.MapRoute(
          name: "web",
          url: "web",
          defaults: new { controller = "Sektorler", action = "Index", id = "3" }
      );

            routes.MapRoute(
          name: "pos_cozumleri_sektor",
          url: "pos_cozumleri_sektor",
          defaults: new { controller = "Sektorler", action = "Index", id = "4" }
      );

            routes.MapRoute(
          name: "donanim",
          url: "donanim",
          defaults: new { controller = "Sektorler", action = "Index", id = "5" }
      );
            routes.MapRoute(
          name: "ozel_yazilim_sektor",
          url: "ozel_yazilim_sektor",
          defaults: new { controller = "Sektorler", action = "Index", id = "6" }
      );

            routes.MapRoute(
          name: "DuyuruHaber",
          url: "DuyuruHaber/{id}",
          defaults: new { controller = "DuyuruHaber", action = "Detay", id = UrlParameter.Optional }
      );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
