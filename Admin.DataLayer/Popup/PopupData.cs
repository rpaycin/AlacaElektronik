using System;
using System.Collections.Generic;
using System.Linq;

namespace Admin.DataLayer.LoginData
{
    public class PopupData : IPopupData
    {
        public List<Popup> GetPopups()
        {
            using (AlacaYazilimWebSiteEntities entities = new AlacaYazilimWebSiteEntities())
            {
                List<Popup> popupDbList = entities.Popup.OrderByDescending(u => u.Aktif.HasValue && u.Aktif.Value).ToList();

                return popupDbList;
            }
        }

        public void SavePopup(Popup popup)
        {
            using (AlacaYazilimWebSiteEntities entities = new AlacaYazilimWebSiteEntities())
            {
                popup.CreateDate = DateTime.Now;
                popup.Aktif = true;
                entities.Popup.Add(popup);

                entities.SaveChanges();
            }
        }

        public void DeletePopup(int popupId)
        {
            using (AlacaYazilimWebSiteEntities entities = new AlacaYazilimWebSiteEntities())
            {
                Popup dbPopup = entities.Popup.FirstOrDefault(f => f.PopupId == popupId);

                dbPopup.Aktif = false;

                entities.SaveChanges();
            }
        }

        public void UpdatePopup(Popup popup)
        {
            using (AlacaYazilimWebSiteEntities entities = new AlacaYazilimWebSiteEntities())
            {
                Popup dbPopup = entities.Popup.FirstOrDefault(f => f.PopupId == popup.PopupId);

                dbPopup.Popup1 = popup.Popup1;
                dbPopup.Sira = popup.Sira;
                dbPopup.Aktif = popup.Aktif;

                entities.SaveChanges();
            }
        }
    }
}
