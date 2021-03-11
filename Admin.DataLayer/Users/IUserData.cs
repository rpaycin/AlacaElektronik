using Admin.Entity;
using System.Collections.Generic;

namespace Admin.DataLayer.LoginData
{
    public interface IUserData
    {
        List<Kullanicilar> GetUsers();

        void UpdateUser(Kullanicilar kullanici);

        void SaveUser(Kullanicilar kullanici);

        void DeleteUser(int kullaniciId);
    }
}
