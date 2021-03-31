using System;
using System.Collections.Generic;
using System.Linq;

namespace Admin.DataLayer.LoginData
{
    public class ProductData : IProductData
    {
        public List<Urun> GetProducts()
        {
            using (AlacaYazilimWebSiteEntities entities = new AlacaYazilimWebSiteEntities())
            {
                List<Urun> productsDbList = entities.Urun.Where(u => u.Aktif.HasValue && u.Aktif.Value).OrderBy(c => c.UrunAdi).ToList();

                return productsDbList;
            }
        }

        public List<Urun> GetSubProducts(int mainGroupId)
        {
            using (AlacaYazilimWebSiteEntities entities = new AlacaYazilimWebSiteEntities())
            {
                List<Urun> productsDbList = entities.Urun.Where(u => u.Aktif.HasValue && u.Aktif.Value && u.FKUrunGrupId == mainGroupId).OrderBy(c => c.UrunAdi).ToList();

                return productsDbList;
            }
        }

        public List<Urun> GetSubAdditionalProducts(int mainGroupId, int productId)
        {
            using (AlacaYazilimWebSiteEntities entities = new AlacaYazilimWebSiteEntities())
            {
                List<Urun> productsDbList = entities.Urun.Where(u => u.Aktif.HasValue && u.Aktif.Value && u.FKUrunGrupId == mainGroupId && u.FKAnaUrunId == productId).OrderBy(c => c.UrunAdi).ToList();

                return productsDbList;
            }
        }

        public void SaveProduct(Urun urun)
        {
            using (AlacaYazilimWebSiteEntities entities = new AlacaYazilimWebSiteEntities())
            {
                urun.CreateDate = DateTime.Now;
                urun.Aktif = true;
                entities.Urun.Add(urun);

                entities.SaveChanges();
            }
        }

        public void DeleteProduct(int urunId)
        {
            using (AlacaYazilimWebSiteEntities entities = new AlacaYazilimWebSiteEntities())
            {
                Urun dbUrun = entities.Urun.FirstOrDefault(f => f.UrunId == urunId);

                entities.Urun.Remove(dbUrun);

                entities.SaveChanges();
            }
        }

        public void UpdateProduct(Urun urun)
        {
            using (AlacaYazilimWebSiteEntities entities = new AlacaYazilimWebSiteEntities())
            {
                Urun dbUrun = entities.Urun.FirstOrDefault(f => f.UrunId == urun.UrunId);

                dbUrun.Aciklama = urun.Aciklama;
                dbUrun.FKUrunGrupId = urun.FKUrunGrupId;
                dbUrun.ListeFiyat = urun.ListeFiyat;
                dbUrun.ListeIskontoOran = urun.ListeIskontoOran;
                dbUrun.UrunAdi = urun.UrunAdi;
                dbUrun.Aktif = urun.Aktif;

                entities.SaveChanges();
            }
        }
    }
}
