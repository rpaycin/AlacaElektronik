using System.Collections.Generic;
using System.Linq;

namespace Admin.DataLayer.LoginData
{
    public class FirmsData : IFirmsData
    {
        public List<FirmaBilgileri> GetFirms()
        {
            using (AlacaYazilimWebSiteEntities entities = new AlacaYazilimWebSiteEntities())
            {
                List<FirmaBilgileri> firmsDbList = entities.FirmaBilgileri.OrderByDescending(u => u.Aktif.HasValue && u.Aktif.Value).ToList();

                return firmsDbList;
            }
        }

        public void SaveFirm(FirmaBilgileri firma)
        {
            using (AlacaYazilimWebSiteEntities entities = new AlacaYazilimWebSiteEntities())
            {
                FirmaBilgileri dbFirma = entities.FirmaBilgileri.Add(firma);

                dbFirma.Aktif = true;
                entities.SaveChanges();
            }
        }

        public void DeleteFirm(int firmaId)
        {
            using (AlacaYazilimWebSiteEntities entities = new AlacaYazilimWebSiteEntities())
            {
                FirmaBilgileri dbFirma = entities.FirmaBilgileri.FirstOrDefault(f => f.Id == firmaId);

                entities.FirmaBilgileri.Remove(dbFirma);

                entities.SaveChanges();
            }
        }

        public void UpdateFirm(FirmaBilgileri firma)
        {
            using (AlacaYazilimWebSiteEntities entities = new AlacaYazilimWebSiteEntities())
            {
                FirmaBilgileri dbFirma = entities.FirmaBilgileri.FirstOrDefault(f => f.Id == firma.Id);

                dbFirma.Adres = firma.Adres;
                dbFirma.CepTelefon = firma.CepTelefon;
                dbFirma.DestekMail = firma.DestekMail;
                dbFirma.Fax = firma.Fax;
                dbFirma.FirmaAdi = firma.FirmaAdi;
                dbFirma.FirmaAdiUzun = firma.FirmaAdiUzun;
                dbFirma.IletisimMail = firma.IletisimMail;
                dbFirma.SatisMail = firma.SatisMail;
                dbFirma.Telefon1 = firma.Telefon1;
                dbFirma.Telefon2 = firma.Telefon2;
                dbFirma.Aktif = firma.Aktif;

                entities.SaveChanges();
            }
        }
    }
}
