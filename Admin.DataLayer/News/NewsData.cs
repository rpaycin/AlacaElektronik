using System;
using System.Collections.Generic;
using System.Linq;

namespace Admin.DataLayer.LoginData
{
    public class NewsData : INewsData
    {
        public List<DuyuruHaber> GetNews()
        {
            using (AlacaYazilimWebSiteEntities entities = new AlacaYazilimWebSiteEntities())
            {
                List<DuyuruHaber> newsDbList = entities.DuyuruHaber.OrderByDescending(u => u.Aktif.HasValue && u.Aktif.Value).ToList();

                return newsDbList;
            }
        }

        public void SaveNews(DuyuruHaber news)
        {
            using (AlacaYazilimWebSiteEntities entities = new AlacaYazilimWebSiteEntities())
            {
                news.CreateDate = DateTime.Now;
                news.Aktif = true;
                entities.DuyuruHaber.Add(news);

                entities.SaveChanges();
            }
        }

        public void DeleteNews(int NewsId)
        {
            using (AlacaYazilimWebSiteEntities entities = new AlacaYazilimWebSiteEntities())
            {
                DuyuruHaber dbNew = entities.DuyuruHaber.FirstOrDefault(f => f.DuyuruId == NewsId);

                entities.DuyuruHaber.Remove(dbNew);

                entities.SaveChanges();
            }
        }

        public void UpdateNews(DuyuruHaber news)
        {
            using (AlacaYazilimWebSiteEntities entities = new AlacaYazilimWebSiteEntities())
            {
                DuyuruHaber dbNew = entities.DuyuruHaber.FirstOrDefault(f => f.DuyuruId == news.DuyuruId);

                dbNew.DuyuruBaslik = news.DuyuruBaslik;
                dbNew.Duyuru = news.Duyuru;
                dbNew.DuyuruKisa = news.DuyuruKisa;
                dbNew.ImageUrl = news.ImageUrl;
                dbNew.Sira = news.Sira;
                dbNew.ImageUrl = news.ImageUrl;
                dbNew.Aktif = news.Aktif;

                entities.SaveChanges();
            }
        }
    }
}
