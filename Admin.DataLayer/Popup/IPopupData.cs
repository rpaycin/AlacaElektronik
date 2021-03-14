using Admin.Entity;
using System.Collections.Generic;

namespace Admin.DataLayer.LoginData
{
    public interface IPopupData
    {
        List<Popup> GetPopups();

        void UpdatePopup(Popup popup);

        void SavePopup(Popup popup);

        void DeletePopup(int popupId);
    }
}
