using System;
using System.Collections.Generic;
using System.Linq;

namespace Admin.DataLayer.LoginData
{
    public class UserData : IUserData
    {
        public List<Kullanicilar> GetUsers()
        {
            using (AlacaYazilimWebSiteEntities entities = new AlacaYazilimWebSiteEntities())
            {
                List<Kullanicilar> UserDbList = entities.Kullanicilar.Where(u => u.Aktif.HasValue && u.Aktif.Value).OrderByDescending(c => c.CreateDate).ToList();

                return UserDbList;
            }
        }

        public void SaveUser(Kullanicilar user)
        {
            using (AlacaYazilimWebSiteEntities entities = new AlacaYazilimWebSiteEntities())
            {
                user.CreateDate = DateTime.Now;
                user.Aktif = true;
                entities.Kullanicilar.Add(user);

                entities.SaveChanges();
            }
        }

        public void DeleteUser(int userId)
        {
            using (AlacaYazilimWebSiteEntities entities = new AlacaYazilimWebSiteEntities())
            {
                Kullanicilar dbKullanici = entities.Kullanicilar.FirstOrDefault(f => f.KullaniciId == userId);

                entities.Kullanicilar.Remove(dbKullanici);

                entities.SaveChanges();
            }
        }

        public void UpdateUser(Kullanicilar user)
        {
            using (AlacaYazilimWebSiteEntities entities = new AlacaYazilimWebSiteEntities())
            {
                Kullanicilar dbKullanici = entities.Kullanicilar.FirstOrDefault(f => f.KullaniciId == user.KullaniciId);

                dbKullanici.KullaniciAdi = user.KullaniciAdi;
                dbKullanici.Email = user.Email;
                dbKullanici.Aciklama = user.Aciklama;
                dbKullanici.Sifre = user.Sifre;
                dbKullanici.Aktif = user.Aktif;

                entities.SaveChanges();
            }
        }
    }
}
