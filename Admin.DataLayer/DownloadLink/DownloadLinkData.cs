using System;
using System.Collections.Generic;
using System.Linq;

namespace Admin.DataLayer.LoginData
{
    public class DownloadLinkData : IDownloadLinkData
    {
        public List<DownloadLink> GetDownloadLinks()
        {
            using (AlacaYazilimWebSiteEntities entities = new AlacaYazilimWebSiteEntities())
            {
                List<DownloadLink> downloadLinkDbList = entities.DownloadLink.Where(u => u.Aktif.HasValue && u.Aktif.Value == 1).ToList();

                return downloadLinkDbList;
            }
        }

        public void SaveDownloadLink(DownloadLink downloadLink)
        {
            using (AlacaYazilimWebSiteEntities entities = new AlacaYazilimWebSiteEntities())
            {
                downloadLink.CreateDate = DateTime.Now;
                downloadLink.Aktif = 1;
                entities.DownloadLink.Add(downloadLink);

                entities.SaveChanges();
            }
        }

        public void DeleteDownloadLink(int downloadLinkId)
        {
            using (AlacaYazilimWebSiteEntities entities = new AlacaYazilimWebSiteEntities())
            {
                DownloadLink dbKullanici = entities.DownloadLink.FirstOrDefault(f => f.DownloadId == downloadLinkId);

                dbKullanici.Aktif = 0;

                entities.SaveChanges();
            }
        }

        public void UpdateDownloadLink(DownloadLink downloadLink)
        {
            using (AlacaYazilimWebSiteEntities entities = new AlacaYazilimWebSiteEntities())
            {
                DownloadLink dbKullanici = entities.DownloadLink.FirstOrDefault(f => f.DownloadId == downloadLink.DownloadId);

                dbKullanici.DownloadAdi = downloadLink.DownloadAdi;
                dbKullanici.DownloadUrl = downloadLink.DownloadUrl;
                dbKullanici.Aciklama = downloadLink.Aciklama;

                entities.SaveChanges();
            }
        }
    }
}
