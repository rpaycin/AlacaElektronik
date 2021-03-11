using System;

namespace Admin.Entity
{
    public class ProductGroup
    {
        public int UrunGrupId { get; set; }
        public Nullable<int> AnaGrupId { get; set; }
        public string AnaGrupAdi { get; set; }
        public string UrunGrupAdi { get; set; }
        public Nullable<bool> Aktif { get; set; }
        public Nullable<int> CreateUser { get; set; }
        public Nullable<System.DateTime> Createdate { get; set; }
    }
}
