using System;
using System.Collections.Generic;
using System.Linq;

namespace Admin.DataLayer.LoginData
{
    public class CustomerWritingData : ICustomerWritingData
    {
        public List<MusteriYazi> GetCustomerWritings()
        {
            using (AlacaYazilimWebSiteEntities entities = new AlacaYazilimWebSiteEntities())
            {
                List<MusteriYazi> customerWritingDbList = entities.MusteriYazi.OrderByDescending(u=>u.Aktif.HasValue && u.Aktif.Value).ToList();

                return customerWritingDbList;
            }
        }

        public void SaveCustomerWriting(MusteriYazi customerWriting)
        {
            using (AlacaYazilimWebSiteEntities entities = new AlacaYazilimWebSiteEntities())
            {
                customerWriting.CreateDate = DateTime.Now;
                customerWriting.Aktif = true;
                entities.MusteriYazi.Add(customerWriting);

                entities.SaveChanges();
            }
        }

        public void DeleteCustomerWriting(int customerWritingId)
        {
            using (AlacaYazilimWebSiteEntities entities = new AlacaYazilimWebSiteEntities())
            {
                MusteriYazi dbCustomerWriting = entities.MusteriYazi.FirstOrDefault(f => f.MusteriYaziId == customerWritingId);

                entities.MusteriYazi.Remove(dbCustomerWriting);

                entities.SaveChanges();
            }
        }

        public void UpdateCustomerWriting(MusteriYazi customerWriting)
        {
            using (AlacaYazilimWebSiteEntities entities = new AlacaYazilimWebSiteEntities())
            {
                MusteriYazi dbCustomerWriting = entities.MusteriYazi.FirstOrDefault(f => f.MusteriYaziId == customerWriting.MusteriYaziId);

                dbCustomerWriting.Isim = customerWriting.Isim;
                dbCustomerWriting.Unvan = customerWriting.Unvan;
                dbCustomerWriting.MusteriYazi1 = customerWriting.MusteriYazi1;

                if (!string.IsNullOrEmpty(customerWriting.ResimUrl))
                {
                    dbCustomerWriting.ResimUrl = customerWriting.ResimUrl;
                }

                dbCustomerWriting.Sira = customerWriting.Sira;
                dbCustomerWriting.FirmaUrl = customerWriting.FirmaUrl;
                dbCustomerWriting.Aktif = customerWriting.Aktif;

                entities.SaveChanges();
            }
        }
    }
}
