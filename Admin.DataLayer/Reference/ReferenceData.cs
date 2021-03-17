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
                List<Referans> referenceDbList = entities.Referans.OrderByDescending(u => u.Aktif.HasValue && u.Aktif.Value).ToList();

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

                entities.Referans.Remove(dbReference);

                entities.SaveChanges();
            }
        }

        public void UpdateReference(Referans reference)
        {
            using (AlacaYazilimWebSiteEntities entities = new AlacaYazilimWebSiteEntities())
            {
                Referans dbReference = entities.Referans.FirstOrDefault(f => f.ReferansId == reference.ReferansId);

                dbReference.ReferansFirmaAdi = reference.ReferansFirmaAdi;
                dbReference.ResimUrl = reference.ResimUrl;
                dbReference.FirmaUrl = reference.FirmaUrl;
                dbReference.Sira = reference.Sira;
                dbReference.Aktif = reference.Aktif;

                entities.SaveChanges();
            }
        }
    }
}
