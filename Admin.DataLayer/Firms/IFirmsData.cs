using Admin.Entity;
using System.Collections.Generic;

namespace Admin.DataLayer.LoginData
{
    public interface IFirmsData
    {
        List<FirmaBilgileri> GetFirms();

        void UpdateFirm(FirmaBilgileri firma);

        void SaveFirm(FirmaBilgileri firma);

        void DeleteFirm(int firmaId);

        FirmaBilgileri GetFirstActiveFirm();
    }
}
