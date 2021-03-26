using Admin.DataLayer;
using System.Collections.Generic;

namespace Alaca.Web.Models
{
    public class NewsModel
    {
        public DuyuruHaber DuyuruHaber { get; set; }
        public List<DuyuruHaber> TumHaberler { get; set; }
    }
}