using Admin.DataLayer;
using System.Collections.Generic;

namespace Alaca.Web.Models
{
    public class HomeModel
    {
        public List<Referans> References { get; set; }

        public List<MusteriYazi> CustomerWritings { get; set; }

        public List<DuyuruHaber> News { get; set; }

        public List<Popup> Popups { get; set; }
    }
}