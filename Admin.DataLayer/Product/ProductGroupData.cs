using System.Collections.Generic;
using System.Linq;
using System;

namespace Admin.DataLayer.LoginData
{
    public class ProductGroupData : IProductGroupData
    {
        public List<UrunGrup> GetProductGroups()
        {
            using (AlacaYazilimWebSiteEntities entities = new AlacaYazilimWebSiteEntities())
            {
                List<UrunGrup> ProductGroupsDbList = entities.UrunGrup.Where(u => u.Aktif.HasValue && u.Aktif.Value).OrderBy(c => c.UrunGrupAdi).ToList();

                return ProductGroupsDbList;
            }
        }

        public List<UrunGrup> GetProductMainGroups()
        {
            using (AlacaYazilimWebSiteEntities entities = new AlacaYazilimWebSiteEntities())
            {
                List<UrunGrup> productGroupsDbList = entities.UrunGrup.Where(u => u.Aktif.HasValue && u.Aktif.Value && (!u.AnaGrupId.HasValue || u.AnaGrupId == 0)).OrderBy(c => c.UrunGrupAdi).ToList();

                return productGroupsDbList;
            }
        }

        public List<UrunGrup> GetProductSubGroups(int mainGroupId)
        {
            using (AlacaYazilimWebSiteEntities entities = new AlacaYazilimWebSiteEntities())
            {
                List<UrunGrup> productGroupsDbList = entities.UrunGrup.Where(u => u.Aktif.HasValue && u.Aktif.Value && u.AnaGrupId == mainGroupId).OrderBy(c => c.UrunGrupAdi).ToList();

                return productGroupsDbList;
            }
        }

        public void SaveProductGroup(UrunGrup urunGrup)
        {
            using (AlacaYazilimWebSiteEntities entities = new AlacaYazilimWebSiteEntities())
            {
                urunGrup.Createdate = DateTime.Now;
                urunGrup.Aktif = true;
                entities.UrunGrup.Add(urunGrup);

                entities.SaveChanges();
            }
        }

        public void DeleteProductGroup(int urunGrupId)
        {
            using (AlacaYazilimWebSiteEntities entities = new AlacaYazilimWebSiteEntities())
            {
                UrunGrup dburunGrup = entities.UrunGrup.FirstOrDefault(f => f.UrunGrupId == urunGrupId);

                entities.UrunGrup.Remove(dburunGrup);

                entities.SaveChanges();
            }
        }

        public void UpdateProductGroup(UrunGrup urunGrup)
        {
            using (AlacaYazilimWebSiteEntities entities = new AlacaYazilimWebSiteEntities())
            {
                UrunGrup dburunGrup = entities.UrunGrup.FirstOrDefault(f => f.UrunGrupId == urunGrup.UrunGrupId);

                dburunGrup.AnaGrupId = urunGrup.AnaGrupId;
                dburunGrup.UrunGrupAdi = urunGrup.UrunGrupAdi;
                dburunGrup.Aktif = urunGrup.Aktif;

                entities.SaveChanges();
            }
        }
    }
}
