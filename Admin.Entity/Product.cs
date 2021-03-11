using System;

namespace Admin.Entity
{
    public partial class Product
    {
        public int UrunId { get; set; }
        public Nullable<int> FKUrunGrupId { get; set; }
        public string UrunGrupText { get; set; }
        public string UrunAdi { get; set; }
        public string Aciklama { get; set; }
        public Nullable<decimal> ListeFiyat { get; set; }
        public Nullable<double> ListeIskontoOran { get; set; }
        public Nullable<bool> Aktif { get; set; }
        public Nullable<int> CreateUser { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}
