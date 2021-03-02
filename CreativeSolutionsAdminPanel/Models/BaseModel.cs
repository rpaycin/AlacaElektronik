using System.Web;
using Admin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
namespace AdminWebPanel.Models
{
    public class BaseModel
    {
        public string UrlLogin = "~/Login/Index";
        public User User { get; set; }

        public List<SelectListItem> GetDropdownList(IEnumerable<OptionList> listOption, int? selectedOptionId)
        {
            List<SelectListItem> listItems = new List<SelectListItem>{new SelectListItem
                                         {
                                             Selected = !selectedOptionId.HasValue,
                                             Text = "Seçiniz...",
                                             Value = "-1"
                                         }};
            if (listOption != null)
            {
                listItems.AddRange(
                    listOption.Select(luOption => new SelectListItem
                    {
                        Selected = (luOption.ID == selectedOptionId),
                        Text = luOption.Value,
                        Value = luOption.ID.ToString()
                    }).ToList()
                );
            }

            return listItems;
        }

        public void LoginControl()
        {
            if (HttpContext.Current.Session["UserInfo"] == null)
                HttpContext.Current.Response.Redirect(UrlLogin);

            User = (User)HttpContext.Current.Session["UserInfo"];
            if (User == null)
                HttpContext.Current.Response.Redirect(UrlLogin);
        }
    }
}