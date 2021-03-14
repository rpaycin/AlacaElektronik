using System;
using System.Collections.Generic;
using System.Linq;

namespace Admin.DataLayer.LoginData
{
    public class ReferenceData : IReferenceData
    {
        public List<Referans> GetReferences()
        {
            using (AlacaYazilimWebSiteEntities entities = new AlacaYazilimWebSiteEntities())
            {
                List<Referans> referenceDbList = entities.Referans.Where(u => u.Aktif.HasValue && u.Aktif.Value).ToList();

                return referenceDbList;
            }
        }

        public void SaveReference(Referans reference)
        {
            using (AlacaYazilimWebSiteEntities entities = new AlacaYazilimWebSiteEntities())
            {
                reference.CreateDate = DateTime.Now;
                reference.Aktif = true;
                entities.Referans.Add(reference);

                entities.SaveChanges();
            }
        }

        public void DeleteReference(int referenceId)
        {
            using (AlacaYazilimWebSiteEntities entities = new AlacaYazilimWebSiteEntities())
            {
                Referans dbReference = entities.Referans.FirstOrDefault(f => f.ReferansId == referenceId);

                dbReference.Aktif = false;

                entities.SaveChanges();
            }
        }

        public void UpdateReference(Referans Reference)
        {
            using (AlacaYazilimWebSiteEntities entities = new AlacaYazilimWebSiteEntities())
            {
                Referans dbReference = entities.Referans.FirstOrDefault(f => f.ReferansId == Reference.ReferansId);

                dbReference.ReferansFirmaAdi = Reference.ReferansFirmaAdi;
                dbReference.ResimUrl = Reference.ResimUrl;
                dbReference.FirmaUrl = Reference.FirmaUrl;
                dbReference.Sira = Reference.Sira;

                entities.SaveChanges();
            }
        }
    }
}
