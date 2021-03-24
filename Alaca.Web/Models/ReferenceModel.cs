using Admin.DataLayer;
using System.Collections.Generic;

namespace Alaca.Web.Models
{
    public class ReferenceModel
    {
        public List<Referans> References { get; set; }

        public List<MusteriYazi> CustomerWritings { get; set; }
    }
}