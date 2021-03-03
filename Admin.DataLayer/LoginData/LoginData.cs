using Admin.DataLayer.Helper;
using Admin.Entity;
using System;
using System.Linq;

namespace Admin.DataLayer.LoginData
{
    public class LoginData : ILoginData
    {
        public Response LoginControl(User user)
        {
            try
            {
                using (AlacaYazilimWebSiteEntities entities = new AlacaYazilimWebSiteEntities())
                {
                    Kullanicilar kullanici = entities.Kullanicilar.FirstOrDefault(l => l.Email == user.EmailAddress && l.Sifre == user.Password && l.Aktif.Value);
                    if (kullanici == null)
                        return MakeResponse.CreateErrorResponse("Kullanıcı bulunamadı!");

                    user = Converter.Convert<Kullanicilar, User>(kullanici);
                    return MakeResponse.CreateSuccessResponse(new object[] { user });
                }
            }
            catch (Exception ex)
            {
                return MakeResponse.CreateErrorResponse(ex);
            }
        }
    }
}
