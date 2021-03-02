using System.Collections.Generic;
using System.Web.Mvc;

namespace AdminWebPanel.Models
{
    public class LoginModel : BaseModel
    {
        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }
        public List<SelectListItem> ListFirm { get; set; }

    }
}