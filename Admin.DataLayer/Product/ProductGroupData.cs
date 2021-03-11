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
                List<UrunGrup> ProductGroupsDbList = entities.UrunGrup.Where(u => u.Aktif.HasValue && u.Aktif.Value).ToList();

                return ProductGroupsDbList;
            }
        }

        public void SaveProductGroup(UrunGrup urunGrup)
        {
            using (AlacaYazilimWebSiteEntities entities = new AlacaYazilimWebSiteEntities())
            {
                urunGrup.Createdate = DateTime.Now;
                urunGrup.Aktif = true;
                UrunGrup dburunGrup = entities.UrunGrup.Add(urunGrup);

                entities.SaveChanges();
            }
        }

        public void DeleteProductGroup(int urunGrupId)
        {
            using (AlacaYazilimWebSiteEntities entities = new AlacaYazilimWebSiteEntities())
            {
                UrunGrup dburunGrup = entities.UrunGrup.FirstOrDefault(f => f.UrunGrupId == urunGrupId);

                dburunGrup.Aktif = false;

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

                entities.SaveChanges();
            }
        }
    }
}
