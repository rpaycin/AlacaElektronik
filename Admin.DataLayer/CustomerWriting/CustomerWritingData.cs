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
                List<MusteriYazi> customerWritingDbList = entities.MusteriYazi.Where(u => u.Aktif.HasValue && u.Aktif.Value).ToList();

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

                dbCustomerWriting.Aktif = false;

                entities.SaveChanges();
            }
        }

        public void UpdateCustomerWriting(MusteriYazi CustomerWriting)
        {
            using (AlacaYazilimWebSiteEntities entities = new AlacaYazilimWebSiteEntities())
            {
                MusteriYazi dbCustomerWriting = entities.MusteriYazi.FirstOrDefault(f => f.MusteriYaziId == CustomerWriting.MusteriYaziId);

                dbCustomerWriting.Isim = CustomerWriting.Isim;
                dbCustomerWriting.Unvan = CustomerWriting.Unvan;
                dbCustomerWriting.MusteriYazi1 = CustomerWriting.MusteriYazi1;
                dbCustomerWriting.ResimUrl = CustomerWriting.ResimUrl;
                dbCustomerWriting.Sira = CustomerWriting.Sira;
                dbCustomerWriting.FirmaUrl = CustomerWriting.FirmaUrl;

                entities.SaveChanges();
            }
        }
    }
}
